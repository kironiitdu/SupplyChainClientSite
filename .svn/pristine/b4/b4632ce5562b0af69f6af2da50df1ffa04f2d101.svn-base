using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class BranchController : Controller
    {
        //
        // GET: /Branch/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "Branch";
            string ActionName = "Add";
            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }
        public ActionResult Edit(int branch_id)
        {
            ViewBag.branch_id = branch_id;
            return View();
        }
	}
}