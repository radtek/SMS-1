using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Bec.TargetFramework.Web.Framework.Helpers;
using Bec.TargetFramework.Entities;
using ServiceStack.Text;

namespace Bec.TargetFramework.UI.Process.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionExpireFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows Authentication is not supported");
            }

            string url = new UrlHelper(filterContext.RequestContext).Action("SessionExpired", "Login", new { Area = "Account" });

            // If the browser session or authentication session has expired...
            if (filterContext.HttpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] == null || !filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // For AJAX requests, we're overriding the returned JSON result with a simple string,
                    // indicating to the calling JavaScript code that a redirect should be performed.
                    filterContext.Result = new JsonResult { Data = new AjaxRequestErrorDTO { RedirectUrl = url, HasRedirectUrl = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    filterContext.HttpContext.Response.StatusCode = 418;
                }
                else
                {
                    // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/, which
                    // simply displays a temporary 5 second notification that they have timed out, and
                    // will, in turn, redirect to the logon page.
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                            { "Controller", "Login" },
                            { "Action", "SessionExpired" },
                            { "Area" , "Account"}
                });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
