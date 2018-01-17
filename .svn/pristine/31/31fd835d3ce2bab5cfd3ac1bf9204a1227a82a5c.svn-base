using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class InventoryAdjustmentController : Controller
    {
        //
        // GET: /InventoryAdjustment/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Accessories()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Chart";
            //string ActionName = "TopTenDealerChart";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");
            return View();
        }

        public ActionResult AccessoriesEdit(int inventory_adjustment_id)
        {
            ViewBag.inventoryAdjustmentId = inventory_adjustment_id;
            return View();
        }

        public ActionResult Approve()
        {
            return View();
        }

        public ActionResult AccessoriesDetails(int inventory_adjustment_id)
        {
            ViewBag.inventoryAdjustmentId = inventory_adjustment_id;
            return View();
        }
	}
}