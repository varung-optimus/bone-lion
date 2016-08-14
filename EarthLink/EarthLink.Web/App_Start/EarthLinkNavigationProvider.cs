using Abp.Application.Navigation;
using Abp.Localization;
using EarthLink.Authorization;

namespace EarthLink.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class EarthLinkNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", EarthLinkConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                )
                //.AddItem(
                //    new MenuItemDefinition(
                //        "Tenants",
                //        L("Tenants"),
                //        url: "#tenants",
                //        icon: "fa fa-globe",
                //        requiredPermissionName: PermissionNames.Pages_Tenants
                //        )
                //)
                .AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Exams",
                        L("Exams"),
                        url: "#exams",
                        icon: "fa fa-newspaper-o",
                        requiredPermissionName: PermissionNames.Pages_Exams
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", EarthLinkConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EarthLinkConsts.LocalizationSourceName);
        }
    }
}
