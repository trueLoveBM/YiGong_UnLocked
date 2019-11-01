using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using YiGong.Authorization.Roles;
using YiGong.Authorization.Users;
using YiGong.MultiTenancy;

namespace YiGong.EntityFrameworkCore
{
    public class YiGongDbContext : AbpZeroDbContext<Tenant, Role, User, YiGongDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public YiGongDbContext(DbContextOptions<YiGongDbContext> options)
            : base(options)
        {
        }
    }
}
