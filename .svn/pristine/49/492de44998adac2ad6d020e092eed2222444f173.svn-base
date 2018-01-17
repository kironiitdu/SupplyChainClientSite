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
    public class InventoryController : Controller
    {
        public ActionResult LoadGridData()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Inventory";
            //string ActionName = "LoadGridData";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");
            return View();
        }
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
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
        public ActionResult InventoryStock()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "InventoryStock";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }

        //For Get ADA Product Inventory Excel Details with IMEI-----------------------------------------
        public void GetAdaProductInventoryDetailsExcel(int product_id, int color_id, int warehouse_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetAdaProductInventoryDetailsExcel?product_id=" + product_id + "&color_id=" + color_id + "&warehouse_id=" + warehouse_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<GrnReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<GrnReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/GrnExcelReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        public void GetAllInventoryStockIMEIExcel(long product_id, long color_id, long product_version_id, long warehouse_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetAllInventoryStockExcel?product_id=" + product_id + "&color_id=" + color_id + "&warehouse_id=" + warehouse_id + "&product_version_id=" + product_version_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<InventoryStockExcelModel> oDeliAndDis = JsonConvert.DeserializeObject<List<InventoryStockExcelModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/InventoryIMEIExcelReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        public void GetAdaProductInventoryPdf(string from_date, string to_date, string product_id, string color_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetProductInventoryExcelData?from_date=" +
                                    from_date + "&to_date=" + to_date + "&product_id=" + product_id + "&color_id=" +
                                    color_id + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<ProductInventoryExcelModel> oDeliAndDis = JsonConvert.DeserializeObject<List<ProductInventoryExcelModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/AdaProductInventoryReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        public void GetPartyWiseInventoryDetailsExcel(int product_id, int color_id, int warehouse_id, int party_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetPartyWiseInventoryDetailsExcel?product_id=" + product_id + "&color_id=" + color_id + "&warehouse_id=" + warehouse_id + "&party_id=" + party_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<partyWiseStockExcelReportModel> objPartyWiseInventoryDetails = JsonConvert.DeserializeObject<List<partyWiseStockExcelReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/partyWiseStockExcelReport.rpt"));
                reportDocument.SetDataSource(objPartyWiseInventoryDetails);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelRecord, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }


        public void GetAdaProductInventoryAllExcel()
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetAdaProductInventoryAllExcel";
            string apidata = wbClient.DownloadString(downloadString);
            List<GrnReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<GrnReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/GrnExcelReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelRecord, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public void GetAllDeliveredIMEIExcel()
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetAllDeliveredIMEIExcel";
            string apidata = wbClient.DownloadString(downloadString);
            List<AllDeliveredIMEI> oAllDeliveredImeis = JsonConvert.DeserializeObject<List<AllDeliveredIMEI>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/AllDeliveredIMEI.rpt"));
                reportDocument.SetDataSource(oAllDeliveredImeis);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public void GetInventoryReport(int warehouse_id, int product_id, int color_id, string from_date, string to_date, int user_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetInventoryReport?warehouse_id=" + warehouse_id + "&product_id=" + product_id + "&color_id=" + color_id + "&from_date=" + from_date + "&to_date=" + to_date + "&user_id=" + user_id + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<InventoryReportModels> objInventory = JsonConvert.DeserializeObject<List<InventoryReportModels>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/InventoryReport.rpt"));

                reportDocument.SetDataSource(objInventory);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        //Stock Report By Kiron :26/09/2016
        public void GetInventoryStockReport(int warehouse_id, int product_id, int color_id, int user_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetInventoryStockReport?warehouse_id=" + warehouse_id + "&product_id=" + product_id + "&color_id=" + color_id + "&user_id=" + user_id + " ";
            string apidata = wbClient.DownloadString(downloadString);
            List<InventoryStockModel> objInventoryStock = JsonConvert.DeserializeObject<List<InventoryStockModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/InventoryStockReport.rpt"));

                reportDocument.SetDataSource(objInventoryStock);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelWorkbook, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public ActionResult ImeiTrace()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "ImeiTrace";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }

        public ActionResult PartyWiseStock()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "PartyWiseStock";

            if ((roleid == null || roleid == string.Empty) || (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }

        public void GetPartyWiseStockReport(int party_id, int user_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/PartyWiseStockReport?party_id=" + party_id + "&user_id=" + user_id + " ";
            string apidata = wbClient.DownloadString(downloadString);
            List<InventoryStockModel> objInventoryStock = JsonConvert.DeserializeObject<List<InventoryStockModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PartyWiseStockReport.rpt"));

                reportDocument.SetDataSource(objInventoryStock);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public ActionResult ImeiMovementCentralToParty()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "ImeiMovementCentralToParty";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }
        public ActionResult CustomerWisePSI()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "CustomerWisePSI";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }
        public ActionResult ADAProductPSI()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "ADAProductPSI";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }

        public ActionResult ProductInventoryExcel()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Inventory";
            //string ActionName = "ProductInventoryExcel";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");

            return View();
        }
        public ActionResult DeliverySummaryReportFromADAMDDBIS()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "DeliverySummaryReportFromADAMDDBIS";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }
        public ActionResult SellThroughBackCustomerToADA()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "SellThroughBackCustomerToADA";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }
        // PSI PDF
        public void GetPSIPdf(string from_date, string to_date, string product_id, string color_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/CustomerWisePSI?from_date=" +
                                    from_date + "&to_date=" + to_date + "&product_id=" + product_id + "&color_id=" +
                                    color_id + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<CustomerWisePSIModel> objPSIPdf = JsonConvert.DeserializeObject<List<CustomerWisePSIModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PSIPDF.rpt"));
                reportDocument.SetDataSource(objPSIPdf);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        public ActionResult PSIDetails()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Inventory";
            string ActionName = "PSIDetails";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }
        // PSI Details PDF
        public void GetPSIDetailsPdf(string from_date, string to_date, string product_id, string color_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/PSIDetails?from_date=" +
                                    from_date + "&to_date=" + to_date + "&product_id=" + product_id + "&color_id=" +
                                    color_id + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<PSIDetailsModel> objPSIPdf = JsonConvert.DeserializeObject<List<PSIDetailsModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PSIDetailsPDF.rpt"));
                reportDocument.SetDataSource(objPSIPdf);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public void GetAllInventoryStockPDF(long product_id, long color_id, long product_version_id, long warehouse_id, long user_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Inventory/GetAllInventoryStockPDF?warehouse_id=" + warehouse_id + "&user_id=" + user_id + "&product_version_id=" + product_version_id + "&color_id=" + color_id + "&product_id=" + product_id + " ";
            string apidata = wbClient.DownloadString(downloadString);
            List<InventoryStockPDFModel> objInventoryStock = JsonConvert.DeserializeObject<List<InventoryStockPDFModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/InventoryStockPDF.rpt"));

                reportDocument.SetDataSource(objInventoryStock);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

    }
}