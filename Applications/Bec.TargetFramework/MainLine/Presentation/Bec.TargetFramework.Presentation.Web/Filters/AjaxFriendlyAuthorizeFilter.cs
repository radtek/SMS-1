using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    public class AjaxFriendlyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new AjaxRequestErrorDTO { RedirectUrl = new UrlHelper(filterContext.RequestContext).Action("Index", "Login", new { Area = "Account" }), HasRedirectUrl = true },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true; //avoid IIS hijacking the result with a custom error page
            }
            else
                base.HandleUnauthorizedRequest(filterContext);
        }
    }
}