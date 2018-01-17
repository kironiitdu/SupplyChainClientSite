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
    public class ToDeliveryController : Controller
    {
        // GET: ToDelivery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MonthlyTransferReport()
        {
            return View();
        }

        public void GetToDeliveryReport(int to_delivery_master_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "/ToDelivery/GetToDeliveryReportById?to_delivery_master_id=" + to_delivery_master_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<ToDeliveryReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<ToDeliveryReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/ToDeliveryReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public void GetMonthlyTransferReport(DateTime from_date, DateTime to_date, long from_warehouse_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "/ToDelivery/GetMonthlyTransferReport?from_date=" + from_date + "&to_date=" + to_date + "&from_warehouse_id="+from_warehouse_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<MonthlyTransferReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<MonthlyTransferReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/MonthlyTransferReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
    }
}