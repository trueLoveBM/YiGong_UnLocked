using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YiGong.Configuration;

namespace YiGong.Web.Host.Startup
{
    [DependsOn(
       typeof(YiGongWebCoreModule))]
    public class YiGongWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public YiGongWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YiGongWebHostModule).GetAssembly());
        }
    }
}
