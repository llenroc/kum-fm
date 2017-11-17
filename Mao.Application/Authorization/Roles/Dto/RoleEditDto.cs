using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Mao.Core.Authorization.Roles;

namespace Mao.Application.Authorization.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class RoleEditDto
    {
        public int? Id { get; set; }

        [Required]
        public string DisplayName { get; set; }
        
        public bool IsDefault { get; set; }
    }
}