using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMSClient.Models;
using DMSClient.Reports.crystal_models;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.ComponentModel;

namespace DMSClient.Controllers
{
    public class InvoiceController : Controller
    {
        //
        // GET: /Invoice/
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Invoice";
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
        //mohiuddin(24.09.2016)
        //Sales Approval
        public ActionResult Approve(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }
        //Finance Approval dealer requisition
        public ActionResult FinanceApprove(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }
        //Finance Approval dealer demo requisition
        public ActionResult FinanceApproveDealerDemo(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }
        public ActionResult FinanceApproveB2B(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }

        //mohiuddin-18.09.2016
        //public static DataTable ToDataTable<T>(List<T> items)
        //{
        //    DataTable dataTable = new DataTable(typeof(T).Name);

        //    //Get all the properties
        //    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in Props)
        //    {
        //        //Setting column names as Property names
        //        dataTable.Columns.Add(prop.Name);
        //    }
        //    foreach (T item in items)
        //    {
        //        var values = new object[Props.Length];
        //        for (int i = 0; i < Props.Length; i++)
        //        {
        //            //inserting property values to datatable rows
        //            values[i] = Props[i].GetValue(item, null);
        //        }
        //        dataTable.Rows.Add(values);
        //    }
        //    //put a breakpoint here and check datatable
        //    return dataTable;
        //}
        //public static DataTable ToDataTable<T>(this IList<T> data)
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
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
        //public static DataTable ToDataTable<T>(this IList<T> data)
        //{
        //    PropertyDescriptorCollection props =
        //        TypeDescriptor.GetProperties(typeof(T));
        //    DataTable table = new DataTable();
        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptor prop = props[i];
        //        table.Columns.Add(prop.Name, prop.PropertyType);
        //    }
        //    object[] values = new object[props.Count];
        //    foreach (T item in data)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item);
        //        }
        //        table.Rows.Add(values);
        //    }
        //    return table;
        //}
        public void GetInvoiceReport(int invoice_master_id)
        {
            try
            {
                DataSet ds = new DataSet();

                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "Invoice/GetInvoiceReportById?invoice_master_id=" + invoice_master_id + " ";
                string apidata = wbClient.DownloadString(downloadString);
                //List<InvoiceReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<InvoiceReportModel>>(apidata);//original code
                InvoiceCombinedModelcs oDeliAndDis = JsonConvert.DeserializeObject<InvoiceCombinedModelcs>(apidata);//19.09.2016
                               
                //////////////////////////////////////////////
                //DataTable dt1 = ToDataTable(oDeliAndDis.InvoiceReportModels);//19.09.2016
                //DataTable dt2 = ToDataTable(oDeliAndDis.RebateReportModels);//19.09.2016
                DataTable dt3 = ToDataTable(oDeliAndDis.ReceivedBreakdownModels);

                //dt1.Merge(dt2);
                //dt1.AcceptChanges();

                //ds.Merge(dt1);
                
               
                /////////////////////////////////////////////


                using (var reportDocument = new ReportDocument())
                {
                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/Invoice.rpt"));
                    //reportDocument.SetDataSource(oDeliAndDis);//original code
                    reportDocument.SetDataSource(oDeliAndDis.InvoiceReportModels);
                    
                    
                    //rebate subreport
                    //if (oDeliAndDis.RebateReportModels.Count>0)
                    //{
                    //    reportDocument.OpenSubreport("rebate").SetDataSource(oDeliAndDis.RebateReportModels);
                    //}
                    //else
                    //{
                    //    reportDocument.OpenSubreport("rebate").SetDataSource(dt2);
                    //}
                    
                    //comments on 17.04.2017-mohi uddin
                    //received breakdown subreport
                    //if (oDeliAndDis.ReceivedBreakdownModels.Count > 0)
                    //{
                    //    reportDocument.OpenSubreport("receivedbreakdown").SetDataSource(oDeliAndDis.ReceivedBreakdownModels);
                    //}
                    //else
                    //{
                    //    reportDocument.OpenSubreport("receivedbreakdown").SetDataSource(dt3);//if assign list and list is empty then it showing error
                    //}
                    
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Invoice Report" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void GetDailySalesReport(int party_id, string from_date, string to_date)
        //{
        //    try
        //    {
        //        WebClient wbClient = new WebClient();
        //        string downloadString = CoreRules.httpRequest() + "Invoice/GetDailySalesReport?party_id=" + party_id + "&from_date=" + from_date + "&to_date=" + to_date + "";
        //        string apidata = wbClient.DownloadString(downloadString);
        //        //List<PartyJournalReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<PartyJournalReportModel>>(apidata);


        //        //using (var reportDocument = new ReportDocument())
        //        //{

        //        //    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PartyJournalReport.rpt"));
        //        //    reportDocument.SetDataSource(oDeliAndDis);
        //        //    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Party Journal Report" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
	}
}