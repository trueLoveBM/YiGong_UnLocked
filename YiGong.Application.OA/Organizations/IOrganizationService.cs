using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using YiGong.Application.OA.Organizations.Dto;

namespace YiGong.Application.OA.Organizations
{
    /// <summary>
    /// 组织机构的Api接口定义
    /// </summary>
    public interface IOrganizationService:IApplicationService
    {
        /// <summary>
        /// 获取所有组织机构
        /// </summary>
        /// <returns></returns>
        List<OrganizationDto> GetAllOrganizationList();


        /// <summary>
        /// 根据组织机构获取组织机构详细信息
        /// </summary>
        /// <param name="OrgId">组织机构id</param>
        /// <returns>组织机构详细信息</returns>
        OrganizationDto GetOrganizationByOrgId(int OrgId);
    }
}
