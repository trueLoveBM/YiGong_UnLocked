using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace YiGong.EntityFrameworkCore
{
    public static class YiGongDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<YiGongDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<YiGongDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection);
        }
    }
}
