using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using DMSClient.Models;
using DMSClient.Reports.crystal_models;
using Newtonsoft.Json;

namespace DMSClient.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            string apiPath = Properties.Settings.Default.ApiPath;
            Session["apiPath"] = apiPath;
            return View();
        }

        public ActionResult RedrictToAdmin()
        {
           // string kk = DateTime.Now.ToString();

            string employeeId = "";
            string customerId = "";
            string roleid = (string)Request.QueryString["role_id"];
            string role_name = (string)Request.QueryString["role_name"];
            string userid = (string)Request.QueryString["user_id"];
            string FullName = (string)Request.QueryString["full_name"];
            string employee_email = (string)Request.QueryString["employee_email"];
            string employee_name = (string)Request.QueryString["employee_name"];
            string user_role_name = (string)Request.QueryString["emp_role_name"];
            bool is_new_password = (Request.QueryString["is_new_password"]=="1");

            customerId = (string)Request.QueryString["customer_id"];
            employeeId = (string)Request.QueryString["employee_id"];
            string companyId = (string)Request.QueryString["company_id"];
          //  string clientIp = (string)Request.QueryString["clientIp"];
            string branchId = (string)Request.QueryString["branch_id"];
            string partyId = (string)Request.QueryString["party_id"];
            string partyTypeId = (string)Request.QueryString["party_type_id"];
            
            string companyCode = CoreRules.GetCompanyCode(int.Parse(companyId));
            string companyName = CoreRules.getCompanyNameById(int.Parse(companyId));
           // string flagPath = CoreRules.getFlagById(int.Parse(companyId));



            Session["user_role_id"] = roleid;
            Session["role_name"] = role_name;
            Session["user_au_id"] = userid;
            Session["full_name"] = FullName;  // changed by asma 20 Feb 2016...
            Session["company_id"] = companyId;
            Session["branch_id"] = branchId; // Shawon 20.03.2016
            Session["company_code"] = companyCode;
            Session["company_name"] = companyName;
           // Session["clientIp"] = clientIp;
            Session["employee_id"] = employeeId;
            Session["customer_id"] = customerId;
            Session["user_email"] = employee_email;
            Session["party_id"] = partyId;//Farzana 29.08.2016
            Session["party_type_id"] = partyTypeId;
            Session["user_name"] = employee_name;
            Session["employee_name"] = employee_name;
            Session["user_role_name"] = user_role_name;
            Session["is_new_password"] = is_new_password;
            if (is_new_password)
            {
                return Redirect("/user/ChangeOwnProfile");
            }
            else
            {
                return Redirect("/Deshboard/Index");
            }

        }

        public ActionResult RedrictToLogin()
        {
            string userid = (string)Session["user_au_id"];

            // Calling Api For sending User_id
            if (userid != null)
            {
                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "LoginLog/LogOutInfoEntry?userId=" +
                                        userid + "";
                string apidata = wbClient.DownloadString(downloadString);
                //Closing Api Connection before Session Abandon

                Session.Clear();
                Session.Abandon();
                return Redirect("/login/Index");
            }
         

            Session.Clear();
            Session.Abandon();
            return Redirect("/login/Index");
        }
        public ActionResult Changepassword()
        {

            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];
            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }

            int user_id = Int32.Parse(userid);
            ViewBag.user_id = user_id;

            return View();
        }
        //24.04.2017
        public ActionResult LogoutLog()
        {

            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];
            //string companyId = (string)Session["company_id"];
            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}

            //int user_id = Int32.Parse(userid);
            //ViewBag.user_id = user_id;

            return View();
        }
    }
}