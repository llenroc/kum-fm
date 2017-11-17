using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Mao.Application.Authorization.Permissions.Dto;

namespace Mao.Application.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}