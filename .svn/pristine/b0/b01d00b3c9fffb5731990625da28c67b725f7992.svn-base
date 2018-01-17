using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class InventoryJournalController : Controller
    {
        //
        // GET: /InventoryJournal/
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "InventoryJournal";
            string ActionName = "Index";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
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