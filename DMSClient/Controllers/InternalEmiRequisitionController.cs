using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public class InternalEmiRequisitionController : Controller
    {
        // GET: InternalEmiRequisition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult InternalEmiRequisitionRfd()
        {
            return View();
        }

        public ActionResult InternalEmiDeliveryList()
        {
            return View();
        }

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


        public void GetInternalEmiDeliveryReport(int delivery_master_id, int user_id)
        {

            var wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "InternalEmiRequisition/GetInternalEmiDeliveryReportById?delivery_master_id=" + delivery_master_id + "&user_id=" + user_id;
            var apidata = wbClient.DownloadString(downloadString);
            var oDeliAndDis = JsonConvert.DeserializeObject<List<DeliveryReportModel>>(apidata);
            DataTable dt = ToDataTable(oDeliAndDis);

            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/InternalEmiDeliveryReport.rpt"));
                //reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.SetDataSource(dt);
                reportDocument.SummaryInfo.ReportTitle = "Delivery Challan";
                reportDocument.SummaryInfo.ReportSubject = "Delivery Challan";
                reportDocument.SummaryInfo.ReportAuthor = "ADA SCM System";
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Delivery_Challan_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public void GetInternalEmiInvoiceReport(int internal_requisition_master_id, int user_id)
        {
            try
            {
                var wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "InternalEmiRequisition/GetInternalEmiInvoiceReport?internal_requisition_master_id=" + internal_requisition_master_id + "&user_id=" + user_id;
                var apidata = wbClient.DownloadString(downloadString);
                InternalEmiCombinedInvoiceReportModel oDeliAndDis = JsonConvert.DeserializeObject<InternalEmiCombinedInvoiceReportModel>(apidata);
                DataTable dt1 = ToDataTable(oDeliAndDis.InternalInvoiceReportModel);


                using (var reportDocument = new ReportDocument())
                {

                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/InternalEmiInvoiceReportData.rpt"));
                    reportDocument.SetDataSource(oDeliAndDis.InternalInvoiceReportModel);

                    if (oDeliAndDis.InstallmentDetailsModel.Count > 0)
                    {
                        reportDocument.OpenSubreport("installmentDetailsSubRpt").SetDataSource(oDeliAndDis.InstallmentDetailsModel);
                    }
                    else
                    {
                        reportDocument.OpenSubreport("installmentDetailsSubRpt").SetDataSource(dt1); //if assign list and list is empty then it showing error
                    }

                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Invoice_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}