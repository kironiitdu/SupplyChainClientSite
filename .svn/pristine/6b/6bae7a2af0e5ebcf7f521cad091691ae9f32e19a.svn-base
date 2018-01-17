using System;
using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class DeshboardController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "Deshboard";
            string ActionName = "index";

            if (string.IsNullOrEmpty(roleid) || string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(companyId))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
            {
                try
                {
                    Response.Redirect("/Error/Index");
                }
                catch (Exception ex)
                {
                    Response.Redirect("/Login/Index");
                }
            }

            string OrderCount = "0";//CoreRules.GetAllOrder(int.Parse(companyId));
            string BatchCount = "0";//CoreRules.GetAllBatch(int.Parse(companyId));
            ViewBag.OrderCount = OrderCount;
            ViewBag.BatchCount = BatchCount;
            return View();
        }
    }
}