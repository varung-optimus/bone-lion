using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace EarthLink.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : EarthLinkControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}