using System.Web.Mvc;

namespace LMS.Web.Controllers
{
    public class AboutController : LMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}