using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    public class TermsAndConditionsFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WebUserObject userObject = filterContext.HttpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] as WebUserObject;
            if (userObject != null && userObject.NeedsTCs)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Area", "Account" }, { "Controller", "AcceptTCs" }, { "Action", "Index" } });
            base.OnActionExecuting(filterContext);
        }
    }
}