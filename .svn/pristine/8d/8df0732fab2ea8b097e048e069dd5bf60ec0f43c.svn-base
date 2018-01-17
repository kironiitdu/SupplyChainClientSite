using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class InvoicingTypeController : Controller
    {
        // GET: InvoicingType
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "InvoicingType";
            string ActionName = "index";
            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }
    }
}