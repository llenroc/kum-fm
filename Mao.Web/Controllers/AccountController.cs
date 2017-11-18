using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Notifications;
using Abp.Runtime.Caching;
using Abp.Runtime.Security;
using Abp.Runtime.Session;
using Abp.Threading;
using Abp.Timing;
using Abp.UI;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Abp.Zero.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Mao.Application.Authorization;
using Mao.Core.MultiTenancy;
using Mao.Core.Web;
using Mao.Core.Authorization.Users;
using Mao.Core.Notifications;
using Mao.Core.Authorization.Roles;
using Mao.Web.Models.Account;
using Mao.Web.Auth;
using Mao.Web.MultiTenancy;
using Mao.Core.Configuration;

namespace Mao.Web.Controllers
{
    public class AccountController : MaoControllerBase
    {
        private readonly LogInManager _logInManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly IUserEmailer _userEmailer;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ITenancyNameFinder _tenancyNameFinder;
        private readonly ICacheManager _cacheManager;
        private readonly IWebUrlService _webUrlService;
        private readonly IAppNotifier _appNotifier;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly IUserLinkManager _userLinkManager;
        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly SignInManager _signInManager;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ILanguageManager _languageManager;
        private readonly IUserPolicy _userPolicy;


        public AccountController(
            LogInManager logInManager,
            UserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            IUserEmailer userEmailer,
            RoleManager roleManager,
            TenantManager tenantManager,
            IUnitOfWorkManager unitOfWorkManager,
            ITenancyNameFinder tenancyNameFinder,
            ICacheManager cacheManager,
            IAppNotifier appNotifier,
            IWebUrlService webUrlService,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            IUserLinkManager userLinkManager,
            INotificationSubscriptionManager notificationSubscriptionManager,
            SignInManager signInManager,
            IAuthenticationManager authenticationManager,
            ILanguageManager languageManager,
            IUserPolicy userPolicy)
        {
            _userManager = userManager;
            _multiTenancyConfig = multiTenancyConfig;
            _userEmailer = userEmailer;
            _roleManager = roleManager;
            _tenantManager = tenantManager;
            _unitOfWorkManager = unitOfWorkManager;
            _tenancyNameFinder = tenancyNameFinder;
            _cacheManager = cacheManager;
            _webUrlService = webUrlService;
            _appNotifier = appNotifier;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _userLinkManager = userLinkManager;
            _notificationSubscriptionManager = notificationSubscriptionManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _languageManager = languageManager;
            _userPolicy = userPolicy;
            _logInManager = logInManager;
        }
        private async Task<Tenant> GetActiveTenantAsync(string tenancyName)
        {
            var tenant = await _tenantManager.FindByTenancyNameAsync(tenancyName);
            if (tenant == null)
            {
                throw new UserFriendlyException(L("ThereIsNoTenantDefinedWithName{0}", tenancyName));
            }

            if (!tenant.IsActive)
            {
                throw new UserFriendlyException(L("TenantIsNotActive", tenancyName));
            }

            return tenant;
        }
        #region Login / Logout
        private bool IsSelfRegistrationEnabled()
        {
            var tenancyName = _tenancyNameFinder.GetCurrentTenancyNameOrNull();
            if (tenancyName.IsNullOrEmpty())
            {
                return !_webUrlService.SupportsTenancyNameInUrl;
            }

            var tenant = AsyncHelper.RunSync(() => GetActiveTenantAsync(tenancyName));
            return SettingManager.GetSettingValueForTenant<bool>(AppSettings.UserManagement.AllowSelfRegistration, tenant.Id);
        }
        public ActionResult Login(string userNameOrEmailAddress = "", string returnUrl = "", string successMessage = "")
        {
            returnUrl = NormalizeReturnUrl(returnUrl);

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;

            return View(
                new LoginFormViewModel
                {
                    TenancyName = _tenancyNameFinder.GetCurrentTenancyNameOrNull(),
                    IsSelfRegistrationEnabled = IsSelfRegistrationEnabled(),
                    SuccessMessage = successMessage,
                    UserNameOrEmailAddress = userNameOrEmailAddress
                });
        }

        [HttpPost]
        [UnitOfWork]
        public virtual async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            returnUrl = NormalizeReturnUrl(returnUrl);
            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }

            var loginResult = await GetLoginResultAsync(loginModel.UsernameOrEmailAddress, loginModel.Password, loginModel.TenancyName);

            var tenantId = loginResult.Tenant == null ? (int?)null : loginResult.Tenant.Id;

            using (UnitOfWorkManager.Current.SetTenantId(tenantId))
            {
                //if (loginResult.User.ShouldChangePasswordOnNextLogin)
                //{
                //    loginResult.User.SetNewPasswordResetCode();

                //    return Json(new AjaxResponse
                //    {
                //        TargetUrl = Url.Action(
                //            "ResetPassword",
                //            new ResetPasswordViewModel
                //            {
                //                TenantId = SimpleStringCipher.Instance.Encrypt(tenantId == null ? null : tenantId.ToString()),
                //                UserId = SimpleStringCipher.Instance.Encrypt(loginResult.User.Id.ToString()),
                //                ResetCode = loginResult.User.PasswordResetCode
                //            })
                //    });
                //}

                //var signInResult = await _signInManager.SignInOrTwoFactor(loginResult, loginModel.RememberMe);
                //if (signInResult == SignInStatus.RequiresVerification)
                //{
                //    return Json(new AjaxResponse
                //    {
                //        TargetUrl = Url.Action(
                //            "SendSecurityCode",
                //            new
                //            {
                //                returnUrl = returnUrl,
                //                rememberMe = loginModel.RememberMe
                //            })
                //    });
                //}

                //Debug.Assert(signInResult == SignInStatus.Success);

                await UnitOfWorkManager.Current.SaveChangesAsync();

                return Json(new AjaxResponse { TargetUrl = returnUrl });
            }
        }

        public ActionResult Logout()
        {
            _authenticationManager.SignOutAll();
            return RedirectToAction("Login");
        }

        private async Task SignInAsync(User user, ClaimsIdentity identity = null, bool rememberMe = false)
        {
            if (identity == null)
            {
                identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            _authenticationManager.SignOutAllAndSignIn(identity, rememberMe);
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        #endregion


        private string NormalizeReturnUrl(string returnUrl, Func<string> defaultValueBuilder = null)
        {
            if (defaultValueBuilder == null)
            {
                defaultValueBuilder = () => Url.Action("Index", "Application");
            }

            if (returnUrl.IsNullOrEmpty())
            {
                return defaultValueBuilder();
            }

            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }

            return defaultValueBuilder();
        }







    }
}