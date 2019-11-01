using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YiGong.OAEntities
{

    [Table(nameof(Organization))]
    public class Organization : Entity
    {
        /// <summary>
        /// 组织机构姓名
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string OrgName { get; set; }

        /// <summary>
        /// 组织机构类型
        /// </summary>
        [MaxLength(50)]
        public string OrgType { get; set; }


        /// <summary>
        /// 组织机构分类
        /// </summary>
        [MaxLength(50)]
        public string OrgClassification { get; set; }


        /// <summary>
        /// 组织机构电话
        /// </summary>
        [MaxLength(50)]
        public string OrgPhone { get; set; }


        /// <summary>
        /// 组织机构id
        /// </summary>
        [MaxLength(500)]
        public string OrgAddress { get; set; }

        /// <summary>
        /// 组织机构编码
        /// 编码规则：
        /// 1.根节点（即没有上级机构）从1开始，到N结束
        /// 2.下级节点，由上级节点的编码加短横线“-”开始，并查询是否有同级节点，没有则从1开始，有则找到最大的数并加1为当前编码，如：1-1，1-2-1
        /// </summary>
        public string OrgCode { get; set; }

        [ForeignKey("ParentOrg")]
        public int? ParentOrg_Id { get; set; }

        /// <summary>
        /// 父级组织机构
        /// </summary>
        public virtual Organization ParentOrg { get; set; }

        /// <summary>
        /// 子组织机构
        /// </summary>
        public virtual List<Organization> ChildOrgs { get; set; }
    }
}
