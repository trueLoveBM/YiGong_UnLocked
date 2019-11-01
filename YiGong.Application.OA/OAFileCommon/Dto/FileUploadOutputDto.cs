using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace YiGong.Application.OA.OAFileCommon.Dto
{
    /// <summary>
    /// 文件上传成功后的实体
    /// </summary>
    public class FileUploadOutputDto
    {
        /// <summary>
        /// 文件名称：文件上传的原始名称
        /// </summary>
        public string FileName { get; set; }


        /// <summary>
        /// 配置的文件保存路径+guid生成的文件名+文件的原始后缀
        /// </summary>
        public string FileUrl { get; set; }


        /// <summary>
        /// 文件的大小
        /// </summary>
        public long FileLength { get; set; }




        /// <summary>
        /// 文件的mimetype
        /// </summary>
        public string FileType { get; set; }
    }
}
