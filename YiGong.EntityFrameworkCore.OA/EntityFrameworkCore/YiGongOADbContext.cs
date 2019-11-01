using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YiGong.OAEntities;

namespace YiGong.EntityFrameworkCore.OA.EntityFrameworkCore
{
    /// <summary>
    /// 办公管理模块的Context
    /// </summary>
    public class YiGongOADbContext : AbpDbContext
    {
        public YiGongOADbContext(DbContextOptions options) : base(options)
        {
        }


        public virtual DbSet<Organization> Organization { get; set; }
    }
}
