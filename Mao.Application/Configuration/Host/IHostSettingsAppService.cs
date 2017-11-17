using System.Threading.Tasks;
using Abp.Application.Services;
using Mao.Application.Configuration.Host.Dto;

namespace Mao.Application.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
