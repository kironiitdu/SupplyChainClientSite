using System.Web.Mvc;
using DMSClient.Models;
//using DMSClient.Reports.crystal_models;

namespace DMSClient.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "createorder";
            string ActionName = "index";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }

        public ActionResult add()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "createorder";
            string ActionName = "index";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            return View();
        }

        public ActionResult edit(int customer_id)
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            ViewBag.customer_id = customer_id;

            return View();
        }

        public ActionResult view(int customer_id)
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string countryId = (string)Session["country_id"];

            string ConName = "createorder";
            string ActionName = "index";

            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (countryId == null || countryId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            ViewBag.customer_id = customer_id;

            return View();
        }

        public ActionResult profile(int customer_id)
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];

            string ConName = "Customer";
            string ActionName = "profile";
            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            if (!permission)
                Response.Redirect("/Error/Index");

            ViewBag.customer_id = customer_id;

            return View();
        }


        //public void GetCustomerInfoReport(int customer_id)
        //{

        //    try
        //    {
        //        WebClient wbClient = new WebClient();
        //        string downloadString = CoreRules.httpRequest() + "Customer/CustomerInfoReportCon?customer_id=" + customer_id;
        //        string apidata = wbClient.DownloadString(downloadString);
        //        List<CustomerInformationReportModels> oCustomerReportModels = JsonConvert.DeserializeObject<List<CustomerInformationReportModels>>("[" + apidata + "]");
        //        using (ReportDocument reportDocument = new ReportDocument())
        //        {
        //            reportDocument.Load(Server.MapPath("~/Reports/crystal_documents/CustomerInformationReports.rpt"));
        //            reportDocument.SetDataSource(oCustomerReportModels);
        //            reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "CustomerInformationReports" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw ;
        //    }
        //}
    }
}