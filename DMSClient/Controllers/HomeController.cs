using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class HomeController : Controller
    {
        [ERPAuthorize()]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
