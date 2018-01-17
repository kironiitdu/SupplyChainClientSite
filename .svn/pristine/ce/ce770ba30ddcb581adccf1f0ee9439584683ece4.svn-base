using DMSClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DMSClient
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
        }
        //protected void Session_Start(Object sender, EventArgs e) { }

        //protected void Session_End(Object sender, EventArgs e)
        //{
        //    string userid = (string)Session["user_au_id"];
        //    WebClient wbClient = new WebClient();
        //    string downloadString = CoreRules.httpRequest() + "LoginLog/LogOutInfoEntry?userId=" +
        //                            userid + "";
        //    string apidata = wbClient.DownloadString(downloadString);
        //    Debug.WriteLine("End. " + Session.SessionID);
        //}
    }
}
