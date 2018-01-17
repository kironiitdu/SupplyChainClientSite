using System.Web.Mvc;

namespace DMSClient.Controllers
{
    public class CreateUserController : Controller
    {
        //
        // GET: /CreateUser/
        public ActionResult Add()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];
            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            return View();
        }

        public ActionResult Index()
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];
            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            return View();
        }

        public ActionResult Edit(int user_id)
        {
            string roleid = (string)Session["user_role_id"];
            string userid = (string)Session["user_au_id"];
            string companyId = (string)Session["company_id"];
            if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty) && (companyId == null || companyId == string.Empty))
            {
                Response.Redirect("/Login/Index");
            }
            ViewBag.user_id = user_id;
            return View();
        }
	}
}