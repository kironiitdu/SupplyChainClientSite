using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class DeliveredCourierInformationController : Controller
    {
        // Added By Kiron 04/10/2016
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "DeliveredCourierInformation";
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
       
        public ActionResult Add(int delivery_master_id)
        {
            ViewBag.delivery_master_id = delivery_master_id;
            return View();
        }


        public ActionResult Edit()
        {
            return View();
        }
    }
}