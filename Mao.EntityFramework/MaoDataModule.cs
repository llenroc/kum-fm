using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Mao.EntityFramework;

namespace Mao
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(MaoCoreModule))]
    public class MaoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<MaoDbContext>(null);
        }
    }
}
