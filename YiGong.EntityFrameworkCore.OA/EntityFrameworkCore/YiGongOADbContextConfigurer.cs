using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace YiGong.EntityFrameworkCore.OA.EntityFrameworkCore
{
    public static class YiGongOADbContextConfigurer
    {
        /// <summary>
        /// 创建 LoggerFactory 的单一实例/全局实例 控制台记录
        /// 下面ConsoleLoggerProvider的构造函数将在未来的3.0中过时，现在可以不管
        /// </summary>
        public static readonly LoggerFactory MyLoggerFactory
              = new LoggerFactory(new[]
              {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information, true)
              });


        public static void Configure(DbContextOptionsBuilder<YiGongOADbContext> builder, string connectionString)
        {
            builder.UseLoggerFactory(MyLoggerFactory).UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<YiGongOADbContext> builder, DbConnection connection)
        {
            builder.UseLoggerFactory(MyLoggerFactory).UseMySql(connection);
        }
    }
}
