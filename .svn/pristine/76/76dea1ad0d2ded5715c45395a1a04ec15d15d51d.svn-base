using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DMSClient.Models;
using DMSClient.Reports.crystal_models;
using Newtonsoft.Json;

namespace DMSClient.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Index()
        {
            var roleid = (string)Session["user_role_id"];
            var userid = (string)Session["user_au_id"];

            var ConName = "Delivery";
            var ActionName = "Index";

            if (string.IsNullOrEmpty(roleid) && string.IsNullOrEmpty(userid))
            {
                Response.Redirect("/Login/Index");
            }
            var permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }
        public ActionResult Add()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Delivery";
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
        //public ActionResult Approve(int delivery_master_id)
        //public ActionResult UpdateApproveStatus(int delivery_master_id, int userid)
        //{
        //    ViewBag.delivery_master_id = delivery_master_id;
        //    ViewBag.user_id = userid;

        //    return View();
        //}

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }


        public void GetDeliveryReport(int delivery_master_id)
        {

            var wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Delivery/GetDeliveryReportById?delivery_master_id=" + delivery_master_id;
            var apidata = wbClient.DownloadString(downloadString);
           var oDeliAndDis = JsonConvert.DeserializeObject<List<DeliveryReportModel>>(apidata);
            DataTable dt = ToDataTable(oDeliAndDis);

            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/DeliveryReport.rpt"));
                //reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.SetDataSource(dt);
                reportDocument.SummaryInfo.ReportTitle = "Delivery Challan";
                reportDocument.SummaryInfo.ReportSubject = "Delivery Challan";
                reportDocument.SummaryInfo.ReportAuthor = "ADA SCM System";
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Delivery_Challan_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }


        //delivery Excel with details IMEI-------
        public void GetDeliveryExcelReportByDeliveryMasterId(int delivery_master_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Delivery/GetDeliveryExcelReportByDeliveryMasterId?delivery_master_id=" + delivery_master_id;
            string apidata = wbClient.DownloadString(downloadString);
            List<DeliveryReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<DeliveryReportModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/DeliveryExcelReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.ExcelRecord, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public ActionResult ConfirmDelivery(int delivery_master_id)
        {
            ViewBag.delivery_master_id = delivery_master_id;
            return View();
        }

        public ActionResult DeliveredList()
        {
            var roleid = (string)Session["user_role_id"];
            var userid = (string)Session["user_au_id"];

            var ConName = "Delivery";
            var ActionName = "DeliveredList";

            if (string.IsNullOrEmpty(roleid) && string.IsNullOrEmpty(userid))
            {
                Response.Redirect("/Login/Index");
            }
            var permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }

        public ActionResult UpdateCourierOrLogisticsInfo(int delivery_master_id)
        {
            ViewBag.delivery_master_id = delivery_master_id;
            return View();
        }
        public ActionResult CancelDelivery(int delivery_master_id)
        {
            ViewBag.delivery_master_id = delivery_master_id;
            return View();
        }
    }
}