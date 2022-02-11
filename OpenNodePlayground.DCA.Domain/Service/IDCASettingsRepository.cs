using OpenNodePlayground.DCA.Domain.Entity;

namespace OpenNodePlayground.DCA.Domain.Service;

public interface IDCASettingsRepository
{
    Task<DCASettings> GetSettings();
    Task<DCASettings> SetSettings(DCASettings settings);
}