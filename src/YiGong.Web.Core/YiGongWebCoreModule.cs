using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using YiGong.Authentication.JwtBearer;
using YiGong.Configuration;
using YiGong.EntityFrameworkCore;
using YiGong.Application.OA;
using YiGong.EntityFrameworkCore.OA.EntityFrameworkCore;
using Abp.Runtime.Caching.Redis;

namespace YiGong
{
    [DependsOn(
         typeof(YiGongApplicationModule),
         typeof(YiGongEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        ,typeof(AbpAspNetCoreSignalRModule),
        typeof(AbpRedisCacheModule),//模块依赖于Redis缓存
        typeof(YiGongOAApplicationModule),
        typeof(YiGongOAEntityFrameworkModule)
     )]
    public class YiGongWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public YiGongWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                YiGongConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(YiGongApplicationModule).GetAssembly()
                 );

            //添加办公管理模块
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(YiGongOAApplicationModule).GetAssembly()
                 );



            //设置所有缓存的默认过期时间(必须放在使用redis缓存之前)
            Configuration.Caching.ConfigureAll(cache =>
            {
                cache.DefaultAbsoluteExpireTime = TimeSpan.FromMinutes(2);
            });
            //设置某个缓存的默认过期时间 根据 "CacheName" 来区分(必须放在使用redis缓存之前)
            Configuration.Caching.Configure("Orgnazation", cache =>
            {
                cache.DefaultAbsoluteExpireTime = TimeSpan.FromMinutes(2);
            });
            //使用redis缓存(必须放在使用redis缓存之前)
            Configuration.Caching.UseRedis(options =>
            {
                options.ConnectionString = _appConfiguration["Abp:RedisCache:ConnectionString"];
                options.DatabaseId = _appConfiguration.GetValue<int>("Abp:RedisCache:DatabaseId");
            });

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YiGongWebCoreModule).GetAssembly());
        }
    }
}
