using System.Reflection;
using Abp.Modules;
using Abp.AutoMapper;

namespace Mao
{
    [DependsOn(typeof(MaoCoreModule), typeof(AbpAutoMapperModule))]
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
