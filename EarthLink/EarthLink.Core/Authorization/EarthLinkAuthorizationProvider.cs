using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace EarthLink.Authorization
{
    public class EarthLinkAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));
            var exams = pages.CreateChildPermission(PermissionNames.Pages_Exams, L("Exams"));

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EarthLinkConsts.LocalizationSourceName);
        }
    }
}
