using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    public class ContentSecurityPolicyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var policy = "script-src 'self' *.googleapis.com *.google.com *.gstatic.com";
            var response = filterContext.HttpContext.Response;
            response.AddHeader("Content-Security-Policy", policy);
            response.AddHeader("X-WebKit-CSP", policy);
            response.AddHeader("X-Content-Security-Policy", policy);
            base.OnActionExecuting(filterContext);
        }
    }
}