using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class ControlTypeController : Controller
    {
        //
        // GET: /ControlType/
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "ControlType";
            string ActionName = "index";
            if (roleid == null || roleid == string.Empty)
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.ListPermission(int.Parse(roleid), ConName.ToLower(), ActionName.ToLower());
            if (!permission)
            {
                Response.Redirect("/Error/Index");
            }
           
            return View();
        }
	}
}