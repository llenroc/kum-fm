using Abp.Authorization;
using Mao.Core.Authorization.Roles;
using Mao.Core.Authorization.Users;
using Mao.Core.MultiTenancy;

namespace Mao.Core.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
