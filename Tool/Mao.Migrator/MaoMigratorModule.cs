using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Mao.EntityFramework;
using Mao.EntityFramework.EntityFramework;

namespace Mao.Migrator
{
    [DependsOn(typeof(MaoDataModule))]
    public class MaoMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MaoDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}