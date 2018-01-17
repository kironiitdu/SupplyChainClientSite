using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMSClient.Controllers
{
    public class TermsAndConditionController : Controller
    {
        //
        // GET: /TermsAndCondition/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddTermsAndCondition()
        {
            return View();
        }
        public ActionResult EditTermsAndCondition(long terms_and_condition_id)
        {
              ViewBag.terms_and_condition_id = terms_and_condition_id;
            return View();
        }
	}
}