using System.Reflection;
using Abp.Modules;

namespace Mao
{
    [DependsOn(typeof(MaoCoreModule))]
    public class MaoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
