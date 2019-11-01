using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YiGong.Application.OA.SMS
{
    /// <summary>
    /// 短信发送的Api忌口
    /// 基于秒嘀云
    /// </summary>
    public interface ISMSService : IApplicationService
    {
        /// <summary>
        /// 向一个电话号码发送短信
        /// 本来想着使用短信发送平台,后面想着算了，直接使用推送，推送到手机上试试
        /// </summary>
        /// <param name="Phone">电话号码</param>
        /// <param name="Title">消息标题</param>
        /// <param name="Msg">发送的信息</param>
        /// <returns>发送成功则返回true，否则抛出500异常，提示发送失败的原因</returns>
        Task<bool> SendMSgToPhone(string Phone, string Title, string Msg);
    }
}
