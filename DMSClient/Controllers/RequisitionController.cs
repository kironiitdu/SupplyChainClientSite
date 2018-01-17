using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DMSClient.Models;
using DMSClient.Reports.crystal_models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DMSClient.Controllers
{
    public class RequisitionController : Controller
    {
        public ActionResult Index()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Requisition";
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

        public ActionResult GetAllForwardedRequisitionListbyUser()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "Requisition";
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

        public ActionResult DeliverableRequisition()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Requisition";
            string ActionName = "DeliverableRequisition";

            if (string.IsNullOrEmpty(roleid) && string.IsNullOrEmpty(userid))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }


        public ActionResult UpcomingSalesOrders()
        {
            return View();
        }

        //dealer & dealer demo requisition list for A
        public ActionResult ListForVerify()
        {
            return View();
        }
        public ActionResult ListForHOOpsForward()
        {
            return View();
        }

        //this list for dealer & dealer demo requisiton list for dealer sales head approval
        public ActionResult ListForApprove()
        {
            return View();
        }
        //this list for B2B requisiton list for B2B sales head approval
        public ActionResult ListForApproveBtoB()
        {
            return View();
        }
        public ActionResult ListDealerDemoRequisition()
        {
            return View();
        }
        public ActionResult ListForVerifyDemo()
        {
            return View();
        }
        public ActionResult ListForDemoApprove()
        {
            return View();
        }
        public ActionResult DealerDemoVerify(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;
            return View();
        }
        public ActionResult DealerDemoApprove(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;
            return View();
        }
        public ActionResult Add()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];

            string ConName = "Requisition";
            string ActionName = "Add";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");
            return View();
        }
     
        public ActionResult Edit(int requisition_master_id)
        {

            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }
        public ActionResult EditDealerDemo(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;
            return View();
        }

        public ActionResult RequisitionDelivery(int requisition_master_id)
        {

            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }

        //mohiuddin(22.09.2016)
        public ActionResult Approve(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }
        //head of operation approval
        public ActionResult HOOpsApprove(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }

        public ActionResult HOOpsApproveDealerDemo(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }
        public ActionResult HOOpsApproveB2B(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;

            return View();
        }

        public ActionResult AddDealerDemo()
        {
            return View();
        }
        public ActionResult AddB2B()
        {
            return View();
        }
        public ActionResult EditB2B(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;
            return View();
        }
        public ActionResult DealerDemoAccountsVerify(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;
            return View();
        }
        public ActionResult B2BAccountsVerify(int requisition_master_id)
        {
            ViewBag.requisition_master_id = requisition_master_id;
            return View();
        }

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
        public void GetRequisitionReport(int requisition_master_id)
        {

            WebClient wbClient = new WebClient();
            string downloadString = CoreRules.httpRequest() + "Requisition/GetRequisitionReportById?requisition_master_id=" + requisition_master_id;
            string apidata = wbClient.DownloadString(downloadString);

            RequisitionCombinedModel oDeliAndDis = JsonConvert.DeserializeObject<RequisitionCombinedModel>(apidata);
            //convert list to datatable
            DataTable dtMain = ToDataTable(oDeliAndDis.RequisitionReportModels);
            //DataTable dtSub = ToDataTable(oDeliAndDis.RebateReportModels);


            using (var reportDocument = new ReportDocument())
            {
                reportDocument.Load(Server.MapPath("~/Reports/crystal_view/RequisitionReport.rpt"));
                reportDocument.SetDataSource(dtMain);

                //rebate subreport
                //if (oDeliAndDis.RebateReportModels.Count > 0)
                //{
                //    reportDocument.OpenSubreport("rebate").SetDataSource(dtSub);
                //}
                //else
                //{
                //    reportDocument.OpenSubreport("rebate").SetDataSource(dtSub);
                //}

                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Requisition Report" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }

        public ActionResult GetAllHOSApprovedRequisitionList()
        {
            return View();
        }
        public ActionResult GetAllOPHsApprovedRequisitionList()
        {
            return View();
        }
	}
}