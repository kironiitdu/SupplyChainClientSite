﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DMSClient.Models;
using DMSClient.Reports.crystal_models;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace DMSClient.Controllers
{
    public class GrnController : Controller
    {
        // GET: Grn
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Grn";
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

            string ConName = "Grn";
            string ActionName = "Add";

            if (string.IsNullOrEmpty(roleid) && string.IsNullOrEmpty(userid))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }


       // public ActionResult DemoGrn()
       // {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Grn";
            //string ActionName = "Add";

            //if (string.IsNullOrEmpty(roleid) && string.IsNullOrEmpty(userid))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");
            //return View();
      //  }

        public ActionResult GrnExcel()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Grn";
            string ActionName = "GrnExcel";

            if (string.IsNullOrEmpty(roleid) && string.IsNullOrEmpty(userid))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }

        //grn pdf report------------------
        public void GetGrnReport(int grn_master_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Grn/GetGrnReportById?grn_master_id=" + grn_master_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<GrnReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<GrnReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/GrnReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }


        public void GetProductGrnDetailsDataPdf(string from_date, string to_date, string product_id, string color_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Grn/GetProductGrnDetailsData?from_date=" +
                                    from_date + "&to_date=" + to_date + "&product_id=" + product_id + "&color_id=" +
                                    color_id + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<GrnReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<GrnReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/GrnExcelReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelRecord, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }



        public void GetGrnExcelReportByGrnMasterId(int grn_master_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Grn/GetGrnExcelReportByGrnMasterId?grn_master_id=" + grn_master_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<GrnReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<GrnReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/GrnExcelReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelRecord, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        //grn Excel with details IMEI-------
        public void GetGrnExcelReportByGrnMasterIdProductIdColorId(int grn_master_id, int product_id, int color_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Grn/GetGrnExcelReportByGrnMasterIdProductIdColorId?grn_master_id=" + grn_master_id + "&product_id=" + product_id + "&color_id=" + color_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<GrnReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<GrnReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/GrnExcelReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelRecord, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        /// <summary>
        /// Maruf: 20.Sep.2016
        /// Get IMEI data from uploaded excel file
        /// </summary>
        /// <returns></returns>
        public object UploadExcel()
        {
            var httpPostedFile = Request.Files["ExcelFiles"];
            string fileExtension = "";
            if (httpPostedFile != null)
            {
                fileExtension = Path.GetExtension(httpPostedFile.FileName);
            }
            if (httpPostedFile != null)
            {
                if (fileExtension == ".xlsx")
                {
                    var package = new ExcelPackage(httpPostedFile.InputStream);
                    DataTable excelData = package.ToDataTable();
                    var jsonResult = JsonConvert.SerializeObject(excelData);
                    return jsonResult;
                }
            }
            return null;
        }

        public void ExportToExcel(DataTable dt, string filename)
        {
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode("Logs.xlsx", System.Text.Encoding.UTF8));

            using (var pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Logs");
                ws.Cells["A1"].LoadFromDataTable(dt, true);
                var ms = new MemoryStream();
                pck.SaveAs(ms);
                ms.WriteTo(Response.OutputStream);
            }

        }
    }
}