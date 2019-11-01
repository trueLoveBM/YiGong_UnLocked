using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using YiGong.Configuration;

namespace YiGong.EntityFrameworkCore.OA.EntityFrameworkCore
{
    public class YiGongConnectionStringResolver : DefaultConnectionStringResolver
    {
        private readonly IConfigurationRoot _appConfiguration;
        public YiGongConnectionStringResolver(IAbpStartupConfiguration configuration, IHostingEnvironment hostingEnvironment) : base(configuration)
        {
            _appConfiguration =
                AppConfigurations.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            if (args["DbContextConcreteType"] as Type == typeof(YiGongOADbContext))
            {
                return _appConfiguration.GetConnectionString(YiGongConsts.ConnectionStringNameOA);
            }

            return base.GetNameOrConnectionString(args);
        }
    }
}
