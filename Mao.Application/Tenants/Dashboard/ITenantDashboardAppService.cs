using Abp.Application.Services;
using Mao.Application.Tenants.Dashboard.Dto;

namespace Mao.Application.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
