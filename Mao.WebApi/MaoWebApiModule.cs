using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace Mao
{
    [DependsOn(typeof(AbpWebApiModule), typeof(MaoApplicationModule))]
    public class MaoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MaoApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
