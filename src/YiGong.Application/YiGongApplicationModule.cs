using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YiGong.Authorization;

namespace YiGong
{
    [DependsOn(
        typeof(YiGongCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class YiGongApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<YiGongAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(YiGongApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
