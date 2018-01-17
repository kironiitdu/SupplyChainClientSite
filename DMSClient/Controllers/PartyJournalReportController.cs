﻿using System;
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


namespace DMSClient.Controllers
{
    public class PartyJournalReportController : Controller
    {
        //
        // GET: /PartyJournalReport/
        public ActionResult Index()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "PartyJournalReport";
            //string ActionName = "Index";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");
            return View();
        }

        public void GetPartyJournalReport(int party_id, DateTime from_date, DateTime to_date)
        {
            try
            {
                WebClient wbClient = new WebClient();
                string downloadString = CoreRules.httpRequest() + "PartyJournal/GetPartyJournalReportById?party_id=" + party_id + "&from_date=" + from_date + "&to_date=" + to_date + "";
                string apidata = wbClient.DownloadString(downloadString);
                List<PartyJournalReportModel> oDeliAndDis = JsonConvert.DeserializeObject<List<PartyJournalReportModel>>(apidata);


                using (var reportDocument = new ReportDocument())
                {

                    reportDocument.Load(Server.MapPath("~/Reports/crystal_view/PartyJournalReport.rpt"));
                    reportDocument.SetDataSource(oDeliAndDis);
                    reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Party Journal Report" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
	}
}