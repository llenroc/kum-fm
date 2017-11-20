using Abp.Configuration.Startup;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abp.MultiTenancy;
using Abp.Runtime;

namespace Mao.Core.Extensions
{

    /// <summary>
    /// 通过扩展方法来对AbpSession进行扩展
    /// </summary>
    public class AbpSessionExtension: ClaimsAbpSession, IAbpSessionExtension
    {
        public AbpSessionExtension(IPrincipalAccessor principalAccessor, IMultiTenancyConfig multiTenancy, ITenantResolver tenantResolver, IAmbientScopeProvider<SessionOverride> sessionOverrideScopeProvider) : base(principalAccessor, multiTenancy, tenantResolver, sessionOverrideScopeProvider)
        {

        }

        //public AbpSessionExtension(IMultiTenancyConfig multiTenancy) : base(multiTenancy)
        //{

        //}

        public string uid => GetClaimValue("uid");

        private string GetClaimValue(string claimType)
        {
            var claimsPrincipal = PrincipalAccessor.Principal;

            var claim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == claimType);
            if (string.IsNullOrEmpty(claim?.Value))
                return null;

            return claim.Value;
        }



        //public static string GetUserEmail(this IAbpSession session)
        //{
        //    return GetClaimValue("uid");
        //}

        //private static string GetClaimValue(string claimType)
        //{
        //    var claimsPrincipal = DefaultPrincipalAccessor.Instance.Principal;

        //    var claim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == claimType);
        //    if (string.IsNullOrEmpty(claim?.Value))
        //        return null;

        //    return claim.Value;
        //}

    }

}
