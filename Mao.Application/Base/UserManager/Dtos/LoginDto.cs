using Abp.AutoMapper;
using Mao.Core.Base;
using System;

namespace Mao.Authorize.UserManager.Dtos
{
    [AutoMap(typeof(User))]
    public class LoginDto
    {
        #region 实体成员
       public string usernameOrEmailAddress { get; set; }
        public string password { get; set; }

        #endregion


    }
}
