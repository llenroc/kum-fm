using System.Reflection;
using Abp.Modules;

namespace Mao
{
    public class MaoCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
