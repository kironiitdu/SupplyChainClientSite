using DMSClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DMSClient.Reports.crystal_models;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace DMSClient.Controllers
{
    public class ReturnController : Controller
    {
        //
        // GET: /Return/
        public ActionResult Index()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Return";
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
        public ActionResult ListForVerify()
        {
            return View();
        }
        public ActionResult ListForReceive()
        {
            return View();
        }
        //Retailer Returned List
        public ActionResult RetailerReturnedList()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Return";
            string ActionName = "RetailerReturnedList";

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

            string ConName = "Return";
            string ActionName = "Add";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");

            return View();
        }
        //all return verify by engineer
        public ActionResult Verify(int return_master_id)
        {
            ViewBag.return_master_id = return_master_id;

            return View();
        }

        public ActionResult Receive(int return_master_id)
        {
            ViewBag.return_master_id = return_master_id;

            return View();
        }

        public ActionResult Replace()
        {
            return View();
        }
        public void GetReturnReport(int return_master_id)
        {
            try
            {
                WebClient wbClient = new WebClient();
                //string downloadString = CoreRules.httpRequest() + "Return/GetReturnReport?return_master_id=" + return_master_id + "";//
                string downloadString = CoreRules.httpRequest() + "Return/ReturnInvoiceReportById?return_master_id=" + return_master_id + "";
                string apidata = wbClient.DownloadString(downloadString);
                List<ReturnReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<ReturnReportModel>>(apidata);


                using (var reportDocument = new ReportDocument())
                {

                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/ReturnInvoice.rpt"));
                    reportDocument.SetDataSource(oDeliAndDis);
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Return Invoice" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}