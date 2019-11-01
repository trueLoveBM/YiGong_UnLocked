using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using YiGong.Configuration;

namespace YiGong.Utils
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot _appConfiguration = AppConfigurations.Get(System.Environment.CurrentDirectory);

        //用法1(有嵌套)：GetAppSetting("Authentication", "JwtBearer:SecurityKey")
        //用法2：GetAppSetting("App", "ServerRootAddress")
        public static string GetAppSetting(string section, string key)
        {
            return _appConfiguration.GetSection(section)[key];
        }

        public static string GetConnectionString(string key)
        {
            return _appConfiguration.GetConnectionString(key);
        }

        //public static T GetValue<T>(string key)
        //{
        //    return _appConfiguration.Get<T>(key);
        //}
    }
}
