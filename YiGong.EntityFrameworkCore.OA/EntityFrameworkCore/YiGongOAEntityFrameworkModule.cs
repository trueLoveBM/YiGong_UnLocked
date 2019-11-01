using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YiGong.EntityFrameworkCore.OA.EntityFrameworkCore.Repositories;
using YiGong.EntityFrameworkCore.Seed;

namespace YiGong.EntityFrameworkCore.OA.EntityFrameworkCore
{

    /// <summary>
    /// 办公管理的模块
    /// </summary>
    [DependsOn(
        typeof(YiGongCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class YiGongOAEntityFrameworkModule : AbpModule
    {

        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            Configuration.ReplaceService(typeof(IConnectionStringResolver), () => { IocManager.Register<IConnectionStringResolver, YiGongConnectionStringResolver>(); });

            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<YiGongOADbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        YiGongOADbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        YiGongOADbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YiGongOAEntityFrameworkModule).GetAssembly());

            //手动注册仓储基类
            //IocManager.Register(typeof(IYiGongRepository<>), typeof(YiGongOARepositoryBase<>));
            //IocManager.Register(typeof(IYiGongRepository<,>), typeof(YiGongOARepositoryBase<,>));
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                //数据库初始化
                SeedHelper.SeedHostDb(IocManager);
            }
        }

    }
}
