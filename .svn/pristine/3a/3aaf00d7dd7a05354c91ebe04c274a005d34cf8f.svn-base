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
    public class EShopRequisitionController : Controller
    {
        // GET: ESopRequisition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cancel(int delivery_master_id)
        {
            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "EshopRequisition/CancelEshopRequisition?delivery_master_id=" + delivery_master_id;
            string apidata = wbClient.DownloadString(downloadString);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddCourier(int delivery_master_id)
        {
            ViewBag.delivery_master_id = delivery_master_id;
            return View();
        }

        public ActionResult ConfirmList()
        {
            return View();
        }

        public ActionResult EshopReturn(int delivery_master_id)
        {
            ViewBag.delivery_master_id = delivery_master_id;
            return View();
        }

        public ActionResult EshopPayment(int delivery_master_id)
        {
            ViewBag.delivery_master_id = delivery_master_id;
            return View();
        }

        public void EshopDeliveryChallanReport(int delivery_master_id)
        {
            try
            {
                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "EshopRequisition/EshopDeliveryChallanReport?delivery_master_id=" + delivery_master_id;
                string apidata = wbClient.DownloadString(downloadString);
                List<EshopDeliveryChallanModel> oDeliAndDis = JsonConvert.DeserializeObject<List<EshopDeliveryChallanModel>>(apidata);


                using (var reportDocument = new ReportDocument())
                {
                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/EshopDeliveryChallan.rpt"));
                    reportDocument.SetDataSource(oDeliAndDis);
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Lot No Print Report" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EshopInvoiceReport(int requisition_master_id)
        {
            try
            {
                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "EshopRequisition/EshopInvoiceReport?requisition_master_id=" + requisition_master_id;
                string apidata = wbClient.DownloadString(downloadString);
                List<EshopInvoiceModel> oDeliAndDis = JsonConvert.DeserializeObject<List<EshopInvoiceModel>>(apidata);


                using (var reportDocument = new ReportDocument())
                {
                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/EshopInvoiceReport.rpt"));
                    reportDocument.SetDataSource(oDeliAndDis);
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Lot No Print Report" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}