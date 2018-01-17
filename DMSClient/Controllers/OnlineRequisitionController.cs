﻿using System;
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
    public class OnlineRequisitionController : Controller
    {
        // GET: OnlineRequisition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Return()
        {
            return View();
        }

        public ActionResult PaymentCollect()
        {
            return View();
        }
        public void GetOnlineDeliveryChallanReport(int delivery_master_id)
        {
            try
            {
                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "OnlineRequisition/GetOnlineDeliveryChallanReport?deliveryMasterId=" + delivery_master_id;
                string apidata = wbClient.DownloadString(downloadString);
                List<OnlineDeliveryChallanModel> oDeliAndDis = JsonConvert.DeserializeObject<List<OnlineDeliveryChallanModel>>(apidata);


                using (var reportDocument = new ReportDocument())
                {
                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/OnlineDeliveryReport.rpt"));      
                    reportDocument.SetDataSource(oDeliAndDis);
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Lot No Print Report" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult OnlinePaymentList()
        {
            return View();
        }

        public ActionResult Payment(long online_invoice_master_id)
        {
            ViewBag.online_invoice_master_id = online_invoice_master_id;
            return View();
        }

        public void GetOnlineInvoiceReport(int online_invoice_master_id)
        {
            try
            {
                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "OnlineRequisition/GetOnlineInvoiceReport?online_invoice_master_id=" + online_invoice_master_id;
                string apidata = wbClient.DownloadString(downloadString);
                List<OnlineInvoiceModel> objInvoiceReport = JsonConvert.DeserializeObject<List<OnlineInvoiceModel>>(apidata);



                using (var reportDocument = new ReportDocument())
                {
                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/OnlineInvoiceReport.rpt"));
                    reportDocument.SetDataSource(objInvoiceReport);
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public ActionResult ReturnList()
        {
            return View();
        }

        public void GetReturnChallanReport(int returnMasterId)
        {
            try
            {
                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "OnlineReturn/GetReturnChallanReport?returnMasterId=" + returnMasterId;
                string apidata = wbClient.DownloadString(downloadString);
                List<OnlineReturnChallanModel> objInvoiceReport = JsonConvert.DeserializeObject<List<OnlineReturnChallanModel>>(apidata);



                using (var reportDocument = new ReportDocument())
                {
                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/OnlineReturnReport.rpt"));
                    reportDocument.SetDataSource(objInvoiceReport);
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}