using System.Text.Json;
using OpenNodePlayground.DCA.Domain.Entity;
using StackExchange.Redis;

namespace OpenNodePlayground.DCA.Domain.Service;

public class RedisDCASettingsRepository : IDCASettingsRepository
{
    private readonly IConnectionMultiplexer _Redis;

    public RedisDCASettingsRepository(IConnectionMultiplexer redis)
    {
        _Redis = redis;
    }

    public async Task<DCASettings> GetSettings()
    {
        var db = _Redis.GetDatabase();
        var settings = await db.StringGetAsync("settings");

        if (!settings.HasValue)
        {
            return default;
        }

        return JsonSerializer.Deserialize<DCASettings>(settings.ToString());
    }

    public async Task<DCASettings> SetSettings(DCASettings settings)
    {
        var serialized = JsonSerializer.Serialize(settings);
        var db = _Redis.GetDatabase();
        var success = await db.StringSetAsync("settings", serialized);

        if (!success)
        {
            // Do something?
        }

        return settings;
    }
}