using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Mao.Application.Authorization.Permissions.Dto;

namespace Mao.Application.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}