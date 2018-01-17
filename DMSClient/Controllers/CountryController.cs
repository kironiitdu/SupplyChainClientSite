using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Country/
        public ActionResult Index()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Country";
            //string ActionName = "Index";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
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