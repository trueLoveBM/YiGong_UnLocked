using Abp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YiGong.Application.OA.OAFileCommon.Dto
{
    /// <summary>
    /// 文件上传的输入dto
    /// </summary>
    public class FileUploadInputDto
    {
        /// <summary>
        /// 要上传的File文件
        /// </summary>
        [Required]
        public IFormFile File { get; set; }
    }
}
