using System.Web.Mvc;

namespace DMSClient.Controllers
{
    public class WorkCenterController : Controller
    {
        // GET: WorkCenter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int work_center_id)
        {
            int workCenterId = work_center_id;
            ViewBag.work_center_id = workCenterId;
            return View();
        }
    }
}