using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YiGong.MultiTenancy.Dto;

namespace YiGong.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

