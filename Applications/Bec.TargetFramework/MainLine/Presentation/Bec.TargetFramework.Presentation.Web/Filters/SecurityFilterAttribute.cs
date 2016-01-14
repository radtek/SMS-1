using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    public class SecurityFilterAttribute : ActionFilterAttribute
    {
        private const string HeaderName = "Strict-Transport-Security";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            var policy = "script-src 'self' *.googleapis.com *.google.com *.gstatic.com 'unsafe-eval'";
            response.AddHeader("Content-Security-Policy", policy);
            response.AddHeader("X-WebKit-CSP", policy);
            response.AddHeader("X-Content-Security-Policy", policy);
            
            response.AddHeader("X-Content-Type-Options", "nosniff");

            response.AddHeader("X-Frame-Options", "SAMEORIGIN");

            // HSTS headers should be sent via HTTPS responses only : http://tools.ietf.org/html/draft-ietf-websec-strict-transport-sec-14#section-7.2
            // They should also not be duplicated
            if (filterContext.HttpContext.Request.IsSecureConnection && filterContext.HttpContext.Response.Headers[HeaderName] == null)
                filterContext.HttpContext.Response.AddHeader(HeaderName, "max-age=31536000; includeSubDomains; preload");

            base.OnActionExecuting(filterContext);
        }
    }
}