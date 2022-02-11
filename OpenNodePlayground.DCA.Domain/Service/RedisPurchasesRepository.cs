using System.Text.Json;
using OpenNodePlayground.DCA.Domain.Entity;
using StackExchange.Redis;

namespace OpenNodePlayground.DCA.Domain.Service;

public class RedisPurchasesRepository : IPurchasesRepository
{
    private readonly IConnectionMultiplexer _Redis;

    public RedisPurchasesRepository(IConnectionMultiplexer redis)
    {
        _Redis = redis;
    }

    public async Task<BitcoinPurchase> AddBitcoinPurchase(BitcoinPurchase bitcoinPurchase)
    {
        var db = _Redis.GetDatabase();
        var serialized = JsonSerializer.Serialize(bitcoinPurchase);

        var len = await db.ListLeftPushAsync("purchases", serialized);

        return bitcoinPurchase;
    }

    public async Task<List<BitcoinPurchase>> GetAllBitcoinPurchases()
    {
        throw new NotImplementedException();
    }

    public async Task<BitcoinPurchase> GetLastBitcoinPurchase()
    {
        var db = _Redis.GetDatabase();
        var count = await db.ListLengthAsync("purchases");
        if (count > 0)
        {
            var lastPurchase = await db.ListGetByIndexAsync("purchases", 0);
            return JsonSerializer.Deserialize<BitcoinPurchase>(lastPurchase.ToString());
        }

        return default(BitcoinPurchase);
    }
}