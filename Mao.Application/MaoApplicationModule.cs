using System.Reflection;
using Abp.Modules;
using Abp.AutoMapper;
using Mao.Core.Authorization;

namespace Mao.Application
{
    [DependsOn(typeof(MaoCoreModule), typeof(AbpAutoMapperModule))]
    public class MaoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper mappings
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                CustomDtoMapper.CreateMappings(mapper);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
