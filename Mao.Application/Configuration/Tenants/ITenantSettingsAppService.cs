using System.Threading.Tasks;
using Abp.Application.Services;
using Mao.Application.Configuration.Tenants.Dto;

namespace Mao.Application.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
