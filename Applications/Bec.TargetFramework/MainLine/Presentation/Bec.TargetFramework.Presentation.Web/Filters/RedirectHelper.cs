using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    public static class RedirectHelper
    {
        public static void JsonFriendlyRedirect(this ActionExecutingContext filterContext, string area = "Account", string controller = "Login", string action = "SessionExpired")
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                // For AJAX requests, we're overriding the returned JSON result with a simple string,
                // indicating to the calling JavaScript code that a redirect should be performed.
                filterContext.Result = new JsonResult { 
                    Data = new AjaxRequestErrorDTO { RedirectUrl = new UrlHelper(filterContext.RequestContext).Action(action, controller, new { Area = area }), HasRedirectUrl = true },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet 
                };
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true; //avoid IIS hijacking the result with a custom error page
            }
            else
            {
                // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                            { "Controller", controller },
                            { "Action", action },
                            { "Area" , area }
                });
            }
        }
    }
}