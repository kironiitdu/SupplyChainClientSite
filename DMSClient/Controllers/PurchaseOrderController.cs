using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DMSClient.Models;
using DMSClient.Reports.crystal_models;
using Newtonsoft.Json;

namespace DMSClient.Controllers
{
    public class PurchaseOrderController : Controller
    {
        // GET: PurchaseOrder
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "PurchaseOrder";
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


        public ActionResult Verify()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "PurchaseOrder";
            string ActionName = "Verify";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }
        
        public ActionResult Approve()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "PurchaseOrder";
            string ActionName = "Approve";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }

        public ActionResult VerifiedPoList()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "PurchaseOrder";
            string ActionName = "VerifiedPoList";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }

        public ActionResult ApprovedPoList()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "PurchaseOrder";
            string ActionName = "ApprovedPoList";

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

            string ConName = "PurchaseOrder";
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
        public ActionResult Edit(int purchase_order_master_id)
        {
            ViewBag.purchaseOrderMasterId = purchase_order_master_id;
            return View();
        }

        public ActionResult UpdatePiInfoOnPo(int purchase_order_master_id)
        {
            ViewBag.purchaseOrderMasterId = purchase_order_master_id;
            return View();
        }

        public ActionResult UpdateLcNoOnPo(int purchase_order_master_id)
        {
            ViewBag.purchaseOrderMasterId = purchase_order_master_id;
            return View();
        }

        public void GetPurchaseOrderListPdf(string from_date, string to_date)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "PurchaseOrder/GetPurchaseOrderExcelData?from_date=" +
                                    from_date + "&to_date=" + to_date + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<PurchaseOrderExcelModel> oDeliAndDis = JsonConvert.DeserializeObject<List<PurchaseOrderExcelModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PoSummeryReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }


        public ActionResult PurchaseOrderExcel()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Grn";
            //string ActionName = "GrnExcel";

            //if (string.IsNullOrEmpty(roleid) && string.IsNullOrEmpty(userid))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");
            return View();
        }

        public void GetPurchaseOrderReport(int purchase_order_master_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "PurchaseOrder/GetPurchaseOrdersReportById?purchase_order_master_id=" + purchase_order_master_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<PoReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<PoReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PoReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }


    }
}