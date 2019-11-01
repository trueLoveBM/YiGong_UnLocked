using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YiGong.Application.OA.Organizations.Dto
{
    public class OrganizationDto : EntityDto<int>
    {
        /// <summary>
        /// 组织机构姓名
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        /// 组织机构类型
        /// </summary>
        public string OrgType { get; set; }


        /// <summary>
        /// 组织机构分类
        /// </summary>
        public string OrgClassification { get; set; }


        /// <summary>
        /// 组织机构电话
        /// </summary>
        public string OrgPhone { get; set; }


        public int? ParentOrg_Id { get; set; }
    }
}
