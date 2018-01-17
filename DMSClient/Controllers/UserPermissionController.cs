using System.Web.Mvc;

namespace DMSClient.Controllers
{
    public class UserPermissionController : Controller
    {
        //
        // GET: /UserPermission/
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            //string ConName = "UserPermission";
            //string ActionName = "index";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");
            
            return View();
        }
	}
}