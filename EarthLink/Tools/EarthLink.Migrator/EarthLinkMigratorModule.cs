using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using EarthLink.EntityFramework;

namespace EarthLink.Migrator
{
    [DependsOn(typeof(EarthLinkDataModule))]
    public class EarthLinkMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<EarthLinkDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}