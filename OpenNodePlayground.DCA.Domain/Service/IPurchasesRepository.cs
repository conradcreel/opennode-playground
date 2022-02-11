using OpenNodePlayground.DCA.Domain.Entity;

namespace OpenNodePlayground.DCA.Domain.Service;

public interface IPurchasesRepository
{
    Task<BitcoinPurchase> AddBitcoinPurchase(BitcoinPurchase bitcoinPurchase);
    Task<BitcoinPurchase> GetLastBitcoinPurchase();
    Task<List<BitcoinPurchase>> GetAllBitcoinPurchases();
}