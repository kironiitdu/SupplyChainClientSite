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
    public class CentralPointOfSaleController : Controller
    {
        // GET: PointOfSale
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "CentralPointOfSale";
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
        public void GetPosInvoiceReport(int pos_master_id)
        {
            try
            {
                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "Pos/PosInvoiceReportById?pos_master_id=" + pos_master_id + "";
                string apidata = wbClient.DownloadString(downloadString);
                List<PosReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<PosReportModel>>(apidata);


                using (var reportDocument = new ReportDocument())
                {

                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PosInvoice.rpt"));
                    reportDocument.SetDataSource(oDeliAndDis);
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Pos Invoice" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}