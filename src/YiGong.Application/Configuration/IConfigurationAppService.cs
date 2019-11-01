using System.Threading.Tasks;
using YiGong.Configuration.Dto;

namespace YiGong.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
