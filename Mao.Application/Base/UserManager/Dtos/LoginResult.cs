using Mao.Application.Authorize;
using Mao.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mao.Base.UserManager.Dtos
{
    public class LoginResult
    {
        //public AbpLoginResult(AbpLoginResultType result, TTenant tenant = null, TUser user = null);
        public LoginResult(MaoLoginResultType result, string userid)
        {
            this.Result = result;
            this.UserId = userid;
           // this.Identity = identity;

        }

        public MaoLoginResultType Result { get; }
        //public TTenant Tenant { get; }
        public string UserId { get; }

    }
}
