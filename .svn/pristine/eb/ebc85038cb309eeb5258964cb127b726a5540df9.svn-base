using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class PartyController : Controller
    {
        //
        // GET: /Party/
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Party";
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

        public ActionResult Add()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Party";
            string ActionName = "Add";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }

        // Maruf 15.Mar.2017
        public ActionResult InitialBalance()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            //string ConName = "Party";
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

        public ActionResult Edit(int party_id)
        {
            ViewBag.party_id = party_id;
            return View();
        }

        //Add party and Warehouse : By Kiron : 19-01-2017
        public ActionResult PartyAndWarehouse()
        {
            return View();
        }
        public ActionResult EditPartyAndWarehouse(int party_id)
        {
            ViewBag.party_id = party_id;
            return View();
        }
        //Mohi Uddin(15.06.2017)
        public ActionResult EditOpeningBalance(long party_id)
        {
            ViewBag.party_id = party_id;

            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
           
            return View();
        }
        public ActionResult EditPartyCreditLimit(long party_id)
        {
            ViewBag.party_id = party_id;

            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            return View();
        }
	}
}