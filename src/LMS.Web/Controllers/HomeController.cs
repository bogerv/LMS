using System.Web.Mvc;

namespace LMS.Web.Controllers
{
    public class HomeController : LMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}