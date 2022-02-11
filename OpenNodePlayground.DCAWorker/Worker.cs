using OpenNode.ApiClient;
using OpenNode.ApiClient.Dto;
using OpenNodePlayground.DCA.Domain.Entity;
using OpenNodePlayground.DCA.Domain.Service;

namespace OpenNodePlayground.DCAWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDCASettingsRepository _SettingsRepo;
    private readonly IPurchasesRepository _PurchasesRepo;
    private readonly OpenNodeClient _OpenNodeClient;

    public Worker(ILogger<Worker> logger,
                    IDCASettingsRepository settingsRepo,
                    IPurchasesRepository purchasesRepo,
                    OpenNodeClient openNodeClient)
    {
        _logger = logger;
        _SettingsRepo = settingsRepo;
        _PurchasesRepo = purchasesRepo;
        _OpenNodeClient = openNodeClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var settings = await _SettingsRepo.GetSettings();

            if (settings == default)
            {
                continue;
            }

            var lastPurchase = await _PurchasesRepo.GetLastBitcoinPurchase();
            var now = DateTime.UtcNow;

            bool timeToBuy = lastPurchase == default ||
                                lastPurchase.PurchaseDateUtc.AddMinutes(settings.RecurrenceMinutes) <= now;

            if (timeToBuy)
            {
                var buyBtc = await _OpenNodeClient.InitiateExchangeAsync(new InitiateCurrencyExchangeDto
                {
                    to = "btc",
                    fiat_amount = settings.Amount
                });

                if (buyBtc != null)
                {
                    var bitcoinPurchase = new BitcoinPurchase
                    {
                        TransactionId = buyBtc.id,
                        Satoshis = buyBtc.btc_amount,
                        Fiat = buyBtc.fiat_amount,
                        PurchaseDateUtc = now
                    };

                    await _PurchasesRepo.AddBitcoinPurchase(bitcoinPurchase);
                }
                else
                {
                    Console.WriteLine("Couldn't buy bitcoin");
                }
            }

            await Task.Delay(60000, stoppingToken);
        }
    }
}