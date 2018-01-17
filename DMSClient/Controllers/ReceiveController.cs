using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DMSClient.Models;
using DMSClient.Reports.crystal_models;
using Newtonsoft.Json;

namespace DMSClient.Controllers
{
    public class ReceiveController : Controller
    {
        public ActionResult Index()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Receive";
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

        public ActionResult Add()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Receive";
            //string ActionName = "Add";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");
            return View();
        }

        public ActionResult ProcessPaymentRequest(int payment_req_id)
        {
            ViewBag.payment_req_id = payment_req_id;
            return View();
        }
        public ActionResult Edit(int receive_id)
        {
            ViewBag.receive_id = receive_id;
            return View();
        }

        public void GetMoneyReceiptReport(int receive_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Receive/GetMoneyReceiptReport?receive_id=" + receive_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<MoneyReceiptModelsOfReceiveReport> objMoneyReceipt = JsonConvert.DeserializeObject<List<MoneyReceiptModelsOfReceiveReport>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/ReceiveReport.rpt"));
                
                reportDocument.SetDataSource(objMoneyReceipt);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }


        public ActionResult PaymentHistory()
        {
            
            return View();
        }




        public void GetPaymentHistoryReport(string from_date, string to_date)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Receive/GetPaymentHistory?from_date=" + from_date + "&to_date=" + to_date + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<PaymentHistoryModel> objPaymentHistory = JsonConvert.DeserializeObject<List<PaymentHistoryModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PaymentHistory.rpt"));

                reportDocument.SetDataSource(objPaymentHistory);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }



        public ActionResult ProductLiftingAndPaymentSummery()
        {

            return View();
        }

        public void GetProductLiftingAndPaymentSummeryReport(string from_date, string to_date,int party_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Receive/ProductLiftingAndPaymentSummery?from_date=" + from_date + "&to_date=" + to_date + "&party_id=" + party_id + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<ProductLiftingAndPaymentSummery> LiftingAndPayment = JsonConvert.DeserializeObject<List<ProductLiftingAndPaymentSummery>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/ProductLiftingAndPaymentSummery.rpt"));

                reportDocument.SetDataSource(LiftingAndPayment);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        public ActionResult ProductLiftingAndPaymentSummeryDetails()
        {

            return View();
        }

        public void GetProductLiftingAndPaymentSummeryDetailsReport(string from_date, string to_date, int party_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Receive/ProductLiftingAndPaymentSummery?from_date=" + from_date + "&to_date=" + to_date + "&party_id=" + party_id + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<ProductLiftingAndPaymentSummery> LiftingAndPayment = JsonConvert.DeserializeObject<List<ProductLiftingAndPaymentSummery>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/ProductLiftingAndPaymentSummeryDetails.rpt"));

                reportDocument.SetDataSource(LiftingAndPayment);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public ActionResult ReceiveListSearch()
        {
            return PartialView();
        }

    }
}