using Abp.Authorization;
using EarthLink.Authorization.Roles;
using EarthLink.MultiTenancy;
using EarthLink.Users;

namespace EarthLink.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
