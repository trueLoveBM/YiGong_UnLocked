using Abp.Authorization;
using YiGong.Authorization.Roles;
using YiGong.Authorization.Users;

namespace YiGong.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
