using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;
using Mao.WebApi;
using Mao.Core;
using Abp.IO;
using Abp.Configuration.Startup;
using Mao.Core.Web;
using Mao.Application;
using Abp.Zero.Configuration;
using Microsoft.Owin.Security;
using Abp;
using System.Reflection;
using Castle.MicroKernel.Registration;

namespace Mao.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
         typeof(AbpZeroOwinModule),
        typeof(MaoDataModule),
        typeof(MaoApplicationModule),
        typeof(MaoWebApiModule))]

    //[DependsOn(
    //    typeof(AbpWebMvcModule),
    //    typeof(AbpZeroOwinModule),
    //    typeof(AbpZeroTemplateDataModule),
    //    typeof(AbpZeroTemplateApplicationModule),
    //    typeof(AbpZeroTemplateWebApiModule),
    //    typeof(AbpWebSignalRModule),
    //    typeof(AbpRedisCacheModule), //AbpRedisCacheModule dependency can be removed if not using Redis cache
    //    typeof(AbpHangfireModule))] //AbpHangfireModule dependency can be removed if not using Hangfire

    public class MaoWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            //Configuration.Navigation.Providers.Add<AppNavigationProvider>();//SPA!
            //Configuration.Navigation.Providers.Add<FrontEndNavigationProvider>();
            //Configuration.Navigation.Providers.Add<MpaNavigationProvider>();//MPA!

            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = WebUrlService.WebSiteRootAddress;



            //不做ajax防伪
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;

        }

        public override void Initialize()
        {
            //IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            ////AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Dependency Injection
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            IocManager.IocContainer.Register(
                Castle.MicroKernel.Registration.Component
                    .For<IAuthenticationManager>()
                    .UsingFactoryMethod(() => HttpContext.Current.GetOwinContext().Authentication)
                    .LifestyleTransient()
                );

            //Areas
            AreaRegistration.RegisterAllAreas();

            //Routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Bundling
            BundleTable.Bundles.IgnoreList.Clear();
            //CommonBundleConfig.RegisterBundles(BundleTable.Bundles);
            //AppBundleConfig.RegisterBundles(BundleTable.Bundles);//SPA!
            //FrontEndBundleConfig.RegisterBundles(BundleTable.Bundles);
            //MpaBundleConfig.RegisterBundles(BundleTable.Bundles);//MPA!



        }
        public override void PostInitialize()
        {
            var server = HttpContext.Current.Server;
            var appFolders = IocManager.Resolve<AppFolders>();

            appFolders.SampleProfileImagesFolder = server.MapPath("~/Common/Images/SampleProfilePics");
            appFolders.TempFileDownloadFolder = server.MapPath("~/Temp/Downloads");
            appFolders.WebLogsFolder = server.MapPath("~/App_Data/Logs");

            try { DirectoryHelper.CreateIfNotExists(appFolders.TempFileDownloadFolder); } catch { }
        }
    }
}
