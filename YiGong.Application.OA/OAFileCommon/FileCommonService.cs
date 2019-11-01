using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.UI;
using ECMS.Application.Project.BaseData.FileCommon;
using Microsoft.AspNetCore.Http;
using YiGong.Application.OA.OAFileCommon.Dto;
using YiGong.Utils;

namespace YiGong.Application.OA.OAFileCommon
{
    /// <summary>
    /// 文件通用的接口 实现
    /// </summary>
    public class FileCommonService : ApplicationService, IFileCommonService
    {

        /// <summary>
        /// 上传一个文件，并返回文件上传成功后的信息
        /// </summary>
        /// <param name="File">要上传的文件实体</param>
        /// <returns>文件上传成功后返回的文件相关信息</returns>
        public async Task<FileUploadOutputDto> UploadFile( IFormFile File)
        {
            try
            {
                //文件的原始名称
                string FileOriginName = File.FileName;

                //读取文件保存的根目录
                string fileSaveRootDir = ConfigHelper.GetAppSetting("App", "FileRootPath");
                //读取办公管理文件保存的模块的根目录
                string fileSaveDir = ConfigHelper.GetAppSetting("App", "OAFiles");
                //文件保存的相对文件夹(保存到wwwroot目录下)
                string absoluteFileDir = fileSaveRootDir + "/" + fileSaveDir;

                //文件保存的路径(应用的工作目录+文件夹相对路径);
                string fileSavePath = Environment.CurrentDirectory + "/wwwroot/" + absoluteFileDir;
                if (!Directory.Exists(fileSavePath))
                {
                    Directory.CreateDirectory(fileSavePath);
                }

                //生成文件的名称
                string Extension = Path.GetExtension(FileOriginName);//获取文件的源后缀
                if (string.IsNullOrEmpty(Extension))
                {
                    throw new UserFriendlyException("文件上传的原始名称好像不对哦，没有找到文件后缀");
                }
                string fileName = Guid.NewGuid().ToString() + Extension;//通过uuid和原始后缀生成新的文件名

                //最终生成的文件的相对路径（xxx/xxx/xx.xx）
                string finalyFilePath = fileSavePath + "/" + fileName;

                FileUploadOutputDto result = new FileUploadOutputDto();


                //打开上传文件的输入流
                Stream stream = File.OpenReadStream();
                //创建输入流的reader
                //var fileType = stream.GetFileType();
                //文件大小
                result.FileLength = stream.Length;
                result.FileName = FileOriginName;
                result.FileType = Extension.Substring(1);
                result.FileUrl = absoluteFileDir + "/" + fileName;

                //开始保存拷贝文件
                FileStream targetFileStream = new FileStream(finalyFilePath, FileMode.OpenOrCreate);
                await stream.CopyToAsync(targetFileStream);


                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("文件上传失败，原因" + ex.Message);
            }
        }
    }
}
