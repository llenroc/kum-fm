using System.Reflection;
using Abp.Modules;
using Abp.AutoMapper;
using Abp.Zero;
using Abp.Localization.Dictionaries;
using Mao.Core.Friendships;
using Mao.Core.Chat;
using Abp.Dependency;
using System;
using Mao.Core.Friendships.Cache;
using Mao.Core.Emailing;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Mao.Core.Debugging;
using Abp.Zero.Configuration;
using Mao.Core.Authorization.Roles;
using Mao.Core.Configuration;
using Mao.Core.Notifications;
using Mao.Core.Features;
using Abp.Localization.Dictionaries.Xml;
using Mao.Core.Authorization.Users;
using Mao.Core.MultiTenancy;
using Castle.MicroKernel.Registration;

namespace Mao
{
    [DependsOn(typeof(AbpZeroCoreModule),  typeof(AbpAutoMapperModule))]
    public class MaoCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //Add/remove localization sources
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    "Mao",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Mao.Core.Localization.AbpZeroTemplate"
                        )
                    )
                );

            //Adding feature providers
            Configuration.Features.Providers.Add<AppFeatureProvider>();

            //Adding setting providers
            Configuration.Settings.Providers.Add<AppSettingProvider>();

            //Adding notification providers
            Configuration.Notifications.Providers.Add<AppNotificationProvider>();

            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = MaoConsts.MultiTenancyEnabled;

            //Enable LDAP authentication (It can be enabled only if MultiTenancy is disabled!)
            //Configuration.Modules.ZeroLdap().Enable(typeof(AppLdapAuthenticationSource));

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            if (DebugHelper.IsDebug)
            {
                //Disabling email sending in debug mode
                IocManager.Register<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
            }

            Configuration.ReplaceService(typeof(IEmailSenderConfiguration), () =>
            {
                Configuration.IocManager.IocContainer.Register(
                    Component.For<IEmailSenderConfiguration, ISmtpEmailSenderConfiguration>()
                    .ImplementedBy<AbpZeroTemplateSmtpEmailSenderConfiguration>()
                    .LifestyleTransient()
                );
            });

            Configuration.Caching.Configure(FriendCacheItem.CacheName, cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(30);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.RegisterIfNot<IChatCommunicator, NullChatCommunicator>();
            IocManager.Resolve<ChatUserStateWatcher>().Initialize();
        }
    }
}
