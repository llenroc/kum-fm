using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Mao.Application.Authorization.Users;
using Mao.Core.Authorization.Users;

namespace Mao.Application.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}