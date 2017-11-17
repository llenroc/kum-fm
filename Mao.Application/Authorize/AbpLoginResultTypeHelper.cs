using System;
using Abp.Authorization;
using Abp.Dependency;
using Abp.UI;
using Abp;

namespace Mao.Application.Authorize
{
    public enum MaoLoginResultType : byte
    {
        Success = 1,
        InvalidUserNameOrEmailAddress = 2,
        InvalidPassword = 3,
        UserIsNotActive = 4,
        InvalidTenancyName = 5,
        TenantIsNotActive = 6,
        UserEmailIsNotConfirmed = 7,
        UnknownExternalLogin = 8,
        LockedOut = 9,
        UserPhoneNumberIsNotConfirmed = 10
    }
  
}
