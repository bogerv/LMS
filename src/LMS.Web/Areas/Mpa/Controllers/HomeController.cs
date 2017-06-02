using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace LMS.Web.Areas.Mpa.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [AbpMvcAuthorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}