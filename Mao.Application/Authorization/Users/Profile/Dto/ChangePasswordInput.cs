using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Auditing;

namespace Mao.Application.Authorization.Users.Profile.Dto
{
    public class ChangePasswordInput
    {
        [Required]
        [DisableAuditing]
        public string CurrentPassword { get; set; }

        [Required]
        [DisableAuditing]
        public string NewPassword { get; set; }
    }
}