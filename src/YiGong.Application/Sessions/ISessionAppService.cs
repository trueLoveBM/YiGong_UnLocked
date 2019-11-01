using System.Threading.Tasks;
using Abp.Application.Services;
using YiGong.Sessions.Dto;

namespace YiGong.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
