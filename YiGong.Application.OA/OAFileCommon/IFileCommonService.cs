using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YiGong.Application.OA.OAFileCommon.Dto;

namespace ECMS.Application.Project.BaseData.FileCommon
{
    /// <summary>
    /// 文件通用的接口 定义
    /// </summary>
    public interface IFileCommonService : IApplicationService
    {
        /// <summary>
        /// 上传一个文件，并返回文件上传成功后的信息
        /// </summary>
        /// <param name="File">要上传的文件实体</param>
        /// <returns>文件上传成功后返回的文件相关信息</returns>
        Task<FileUploadOutputDto> UploadFile( IFormFile File);
    }
}
