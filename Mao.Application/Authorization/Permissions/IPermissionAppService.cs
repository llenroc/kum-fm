using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Mao.Application.Authorization.Permissions.Dto;

namespace Mao.Application.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
