using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace EarthLink
{
    [DependsOn(typeof(EarthLinkCoreModule), typeof(AbpAutoMapperModule))]
    public class EarthLinkApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
