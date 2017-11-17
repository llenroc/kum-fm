using System.Threading.Tasks;
using Abp.Configuration;

namespace Mao.Core.Timing
{
    public interface ITimeZoneService
    {
        Task<string> GetDefaultTimezoneAsync(SettingScopes scope, int? tenantId);
    }
}
