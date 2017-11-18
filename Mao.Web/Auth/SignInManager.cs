using Abp.Authorization;
using Abp.Configuration;
using Abp.Domain.Uow;
using Mao.Core.Authorization.Roles;
using Mao.Core.Authorization.Users;
using Mao.Core.MultiTenancy;
using Microsoft.Owin.Security;
namespace Mao.Web.Auth
{
    public class SignInManager : AbpSignInManager<Tenant, Role, User>
    {
        public SignInManager(
            UserManager userManager, 
            IAuthenticationManager authenticationManager, 
            ISettingManager settingManager,
            IUnitOfWorkManager unitOfWorkManager) 
            : base(
                  userManager, 
                  authenticationManager,
                  settingManager,
                  unitOfWorkManager)
        {
        }
    }
}