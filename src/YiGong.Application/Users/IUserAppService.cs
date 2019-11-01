using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YiGong.Roles.Dto;
using YiGong.Users.Dto;

namespace YiGong.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
