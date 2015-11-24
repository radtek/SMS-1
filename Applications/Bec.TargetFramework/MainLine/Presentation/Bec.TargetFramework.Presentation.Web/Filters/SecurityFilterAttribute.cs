using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    public class SecurityFilterAttribute : ActionFilterAttribute
    {
        private const string HeaderName = "Strict-Transport-Security";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            //Smart Admin & I think kendo prevent us from using these nice headers:
            //var policy = "script-src 'self' *.googleapis.com *.google.com *.gstatic.com";
            //response.AddHeader("Content-Security-Policy", policy);
            //response.AddHeader("X-WebKit-CSP", policy);
            //response.AddHeader("X-Content-Security-Policy", policy);
            
            response.AddHeader("X-Content-Type-Options", "nosniff");

            response.AddHeader("X-Frame-Options", "DENY");

            // HSTS headers should be sent via HTTPS responses only : http://tools.ietf.org/html/draft-ietf-websec-strict-transport-sec-14#section-7.2
            // They should also not be duplicated
            if (filterContext.HttpContext.Request.IsSecureConnection && filterContext.HttpContext.Response.Headers[HeaderName] == null)
                filterContext.HttpContext.Response.AddHeader(HeaderName, "max-age=31536000; includeSubDomains; preload");

            base.OnActionExecuting(filterContext);
        }
    }
}