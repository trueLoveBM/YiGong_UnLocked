using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using YiGong.Configuration.Dto;

namespace YiGong.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : YiGongAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
