using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace YiGong.Controllers
{
    public abstract class YiGongControllerBase: AbpController
    {
        protected YiGongControllerBase()
        {
            LocalizationSourceName = YiGongConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
