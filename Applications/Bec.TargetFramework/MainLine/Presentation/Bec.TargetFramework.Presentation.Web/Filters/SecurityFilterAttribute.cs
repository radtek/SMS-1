using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    public class SecurityFilterAttribute : FilterAttribute, IResultFilter
    {
        private const string HeaderName = "Strict-Transport-Security";
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            var policy = "script-src 'self' *.googleapis.com *.google.com *.gstatic.com 'unsafe-eval'";
            response.AddHeader("Content-Security-Policy", policy);
            response.AddHeader("X-WebKit-CSP", policy);
            response.AddHeader("X-Content-Security-Policy", policy);
            response.AddHeader("X-Content-Type-Options", "nosniff");
            response.AddHeader("X-Frame-Options", "SAMEORIGIN");
            response.AddHeader("X-XSS-Protection", "1; mode=block");

            // HSTS headers should be sent via HTTPS responses only : http://tools.ietf.org/html/draft-ietf-websec-strict-transport-sec-14#section-7.2
            // They should also not be duplicated
            if (filterContext.HttpContext.Request.IsSecureConnection && filterContext.HttpContext.Response.Headers[HeaderName] == null)
                filterContext.HttpContext.Response.AddHeader(HeaderName, "max-age=31536000; includeSubDomains; preload");

            // cache
            response.Cache.SetCacheability(HttpCacheability.NoCache);  // HTTP 1.1
            response.Cache.AppendCacheExtension("no-cache, no-store, must-revalidate"); 
            response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            response.AppendHeader("Expires", "-1"); // Proxies.
        }
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}