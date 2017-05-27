using System.Web.Mvc;

namespace LMS.Web.Controllers
{
    public class HomeController : LmsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}