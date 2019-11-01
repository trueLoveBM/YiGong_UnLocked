using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YiGong.Application.OA.Organizations.Dto;
using YiGong.Authorization;
using YiGong.OAEntities;

namespace YiGong.Application.OA
{
    [DependsOn(
      typeof(YiGongCoreModule),
      typeof(AbpAutoMapperModule))]
    public class YiGongOAApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(YiGongOAApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg =>
                {
                    cfg.AddMaps(thisAssembly);
                    cfg.CreateMap<Organization, OrganizationDto>();
                }
            );

        }
    }
}
