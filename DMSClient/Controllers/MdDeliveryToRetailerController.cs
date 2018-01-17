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
    public class MdDeliveryToRetailerController : Controller
    {
        // GET: MdDeliveryToRetailer
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "MdDeliveryToRetailer";
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

        public ActionResult RetailerDeliveryInformation()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "MdDeliveryToRetailer";
            string ActionName = "RetailerDeliveryInformation";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }

        public void GetRetailerDeliveryInformationPdf(string from_date, string to_date, int party_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "RetailerDelivery/GetRetailerDeliveryformation?from_date=" +
                                    from_date + "&to_date=" + to_date + "&party_id=" + party_id + "";
            string apidata = wbClient.DownloadString(downloadString);
            List<RetailerDeliveryInfoModel> oDeliAndDis = JsonConvert.DeserializeObject<List<RetailerDeliveryInfoModel>>(apidata);


            using (var reportDocument = new ReportDocument())
            {

                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/RetailerDeliveryInfoReport.rpt"));
                reportDocument.SetDataSource(oDeliAndDis);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
    }
}