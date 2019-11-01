using Abp.Application.Services;
using Jiguang.JPush;
using Jiguang.JPush.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YiGong.Utils;

namespace YiGong.Application.OA.SMS
{
    /// <summary>
    /// 短信发送的Api忌口
    /// 基于秒嘀云
    /// </summary>
    public class SMSService : ApplicationService, ISMSService
    {
        /// <summary>
        /// 向一个电话号码发送短信
        /// 本来想着使用短信发送平台,后面想着算了，直接使用推送，推送到手机上试试
        /// </summary>
        /// <param name="Phone">电话号码</param>
        /// <param name="Title">消息标题</param>
        /// <param name="Msg">发送的信息</param>
        /// <returns>发送成功则返回true，否则抛出500异常，提示发送失败的原因</returns>
        public async Task<bool> SendMSgToPhone(string Phone, string Title, string Msg)
        {
            //极光服务器发送地址
            //https://api.jpush.cn/v3/push

            //获取极光推送相关配置信息
            string AppKey = ConfigHelper.GetAppSetting("App", "AppKey");
            string MasterSecret = ConfigHelper.GetAppSetting("App", "MasterSecret");
            //
            JPushClient client = new JPushClient(AppKey, MasterSecret);
            PushPayload payLoad = JPushObjecWithExtrasAndMessage(Title,Msg,Phone);//设置推送的具体参数

            try
            {
                var reslut = await client.SendPushAsync(payLoad);//推送通知

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 生成一个JPush的通知信息实体
        /// </summary>
        /// <returns></returns>
        private PushPayload JPushObjecWithExtrasAndMessage(string Title, string Msg,string phone)
        {
            PushPayload pushPayload = new PushPayload()
            {
                Platform = new List<string> { "android" },
                Audience = "all",
                Notification = new Notification
                {
                    Alert = Title,
                    Android = new Android
                    {
                        Alert = Msg,
                        Title = Title
                    },
                },
                Message = new Message
                {
                    Title = Title,
                    Content = Msg,
                    Extras = new Dictionary<string, string>
                    {
                        ["phone"] = phone//电话号码
                    }
                },
                Options = new Options
                {
                    IsApnsProduction = true // 设置 iOS 推送生产环境。不设置默认为开发环境。
                }
            };


            //pushPayload.Platform = "android";//JPush 当前支持 Android, iOS, Windows Phone 三个平台的推送。其关键字分别为："android", "ios", "winphone"。
            //pushPayload.Audience = "all";//推送设备对象，表示一条推送可以被推送到哪些设备列表。确认推送设备对象，JPush 提供了多种方式，比如：别名、标签、注册 ID、分群、广播等。
            //Notification notification = new Notification();
            //notification.Alert = null;//通知的内容在各个平台上，都可能只有这一个最基本的属性 "alert"。这个位置的 "alert" 属性（直接在 notification 对象下），是一个快捷定义，各平台的 alert 信息如果都一样，则可不定义。如果各平台有定义，则覆盖这里的定义。
            //notification.Android.Alert = "这里是通知内容";//必填	通知内容 这里指定了，则会覆盖上级统一指定的 alert 信息；内容可以为空字符串，则表示不展示到通知栏
            return pushPayload;
        }

    }
}
