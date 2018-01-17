using System.Web.Mvc;
using DMSClient.Models;

namespace OrderSysClient.Controllers
{
    public class ReceivingController : Controller
    {
        //
        // GET: /Receiving/
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "Receiving";
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

        public ActionResult Add()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "Receiving";
            string ActionName = "add";
            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            ViewBag.receive_master_id = "0";

            if (Request.QueryString["receive_master_id"] != null)
            {
                ViewBag.receive_master_id = Request.QueryString["receive_master_id"];
            }
            ViewBag.po_master_id = "0";

            if (Request.QueryString["po_master_id"] != null)
            {
                ViewBag.po_master_id = Request.QueryString["po_master_id"];
            }
            return View();
        }

        public ActionResult PurchaseReceive()
        {
            return View();
        }
    }
}