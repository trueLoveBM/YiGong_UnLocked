using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using YiGong.Configuration;
using YiGong.Web;

namespace YiGong.EntityFrameworkCore.OA.EntityFrameworkCore
{
    public class YiGongOADbContextFactory : IDesignTimeDbContextFactory<YiGongOADbContext>
    {
        public YiGongOADbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<YiGongOADbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            YiGongOADbContextConfigurer.Configure(builder, configuration.GetConnectionString(YiGongConsts.ConnectionStringNameOA));

            return new YiGongOADbContext(builder.Options);
        }
    }
}
