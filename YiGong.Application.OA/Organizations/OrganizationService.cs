using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YiGong.Application.OA.Organizations.Dto;
using YiGong.EntityFrameworkCore.OA.EntityFrameworkCore.Repositories;
using YiGong.OAEntities;

namespace YiGong.Application.OA.Organizations
{
    /// <summary>
    /// 组织机构的Api接口实现
    /// </summary>
    public class OrganizationService : ApplicationService, IOrganizationService
    {
        IRepository<Organization> OrganizationRepository;
       private readonly ICacheManager cacheManager;


        public OrganizationService(IRepository<Organization> OrganizationRepository, ICacheManager cacheManager)
        {
            this.OrganizationRepository = OrganizationRepository;
            this.cacheManager = cacheManager;
        }

        /// <summary>
        /// 获取所有组织机构
        /// </summary>
        /// <returns></returns>
        public List<OrganizationDto> GetAllOrganizationList()
        {
            List<Organization> organizations = cacheManager.GetCache("Orgnazation").Get("AllOrgzations", () => OrganizationRepository.GetAllList());
            List<OrganizationDto> result = ObjectMapper.Map<List<OrganizationDto>>(organizations);
            return result;
        }


        /// <summary>
        /// 根据组织机构获取组织机构详细信息
        /// </summary>
        /// <param name="OrgId">组织机构id</param>
        /// <returns>组织机构详细信息</returns>
        public OrganizationDto GetOrganizationByOrgId(int OrgId)
        {
            throw new NotImplementedException();
        }
    }
}
