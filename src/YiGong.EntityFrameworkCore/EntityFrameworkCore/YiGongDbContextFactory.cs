using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using YiGong.Configuration;
using YiGong.Web;

namespace YiGong.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class YiGongDbContextFactory : IDesignTimeDbContextFactory<YiGongDbContext>
    {
        public YiGongDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<YiGongDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            YiGongDbContextConfigurer.Configure(builder, configuration.GetConnectionString(YiGongConsts.ConnectionStringName));

            return new YiGongDbContext(builder.Options);
        }
    }
}
