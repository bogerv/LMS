using System.Web.Mvc;

namespace LMS.Web.Controllers
{
    public class AboutController : LmsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}