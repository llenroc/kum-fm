using System.Reflection;
using Abp.Modules;

namespace Mao
{
    [DependsOn(typeof(MaoCoreModule))]
    public class MaoApplicationModule : AbpModule
    {
        //public override void PreInitialize()
        //{
        //    //Adding authorization providers
        //    Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

        //    //Adding custom AutoMapper mappings
        //    Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
        //    {
        //        CustomDtoMapper.CreateMappings(mapper);
        //    });
        //}

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
