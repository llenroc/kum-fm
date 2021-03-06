using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Mao.Core.Authorization.Users;

namespace Mao.Application.Authorization.Users.Profile.Dto
{
    [AutoMap(typeof(User))]
    public class CurrentUserProfileEditDto
    {
       

        [Required]
        [StringLength(User.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(User.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public string Timezone { get; set; }
    }
}