using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DMSClient.Models
{

    //public class ERPAuthorizeAttribute : AuthorizeAttribute
    //{

    //    protected override bool AuthorizeCore(HttpContextBase httpContext)
    //    {
    //        return base.AuthorizeCore(httpContext);
    //    }
    //}
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ERPAuthorizeAttribute : System.Attribute
    {

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }
        //public ERPAuthorizeAttribute()
        //{
        //    int x = 0;
        //    if (x == 0)
        //    {

        //        new AuthorizationContext().HttpContext.Response.Redirect("~/Home/About");

        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

    }
}