using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DMSClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyActionFilterAttribute());
        }
    }

    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        
        
        
        
        {
            HttpContext.Current.Session["current_url"] = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() + "_" + filterContext.ActionDescriptor.ActionName.ToLower();
        }
    }
}
