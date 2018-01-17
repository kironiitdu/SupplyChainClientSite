﻿using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class ControlController : Controller
    {
        //
        // GET: /Control/
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "Control";
            string ActionName = "index";
            if (roleid == null || roleid == string.Empty)
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

            string ConName = "Control";
            string ActionName = "Add";
            if (roleid == null || roleid == string.Empty)
                if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
                {
                    Response.Redirect("/Login/Index");
                }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }

        public ActionResult Edit(int control_id)
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }

            //string roleid = (string)Session["user_role_id"];
            //string ConName = "Control";
            //string ActionName = "edit";
            //bool permission = CoreRules.ListPermission(int.Parse(roleid), ConName.ToLower(), ActionName.ToLower());
            //if (!permission)
            //{
            //    Response.Redirect("/Error/Index");
            //}
            int controlId = (control_id);
            ViewBag.control_id = controlId;
            return View();
        }

        public ActionResult GetMemoryConsumptionStatus()
        {
            return View();

        }
    }
}