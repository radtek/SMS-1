using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Method,
        Inherited = true,
        AllowMultiple = true
    )]
    public class ClaimsRequiredAttribute : ActionFilterAttribute
    {
        private string _action;
        private string[] _resources;

        public ClaimsRequiredAttribute(string action, params string[] resources)
        {
            _action = action;
            _resources = resources;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!string.IsNullOrWhiteSpace(_action))
            {
                Check(filterContext, _action, _resources);
            }
            else
            {
                var action = filterContext.RouteData.Values["action"] as string;
                var controller = filterContext.RouteData.Values["controller"] as string;
                Check(filterContext, action, controller);
            }
        }

        public void Check(ActionExecutingContext filterContext, string action, params string[] resources)
        {
            if (!ClaimsAuthorization.CheckAccess(action, resources))
                filterContext.JsonFriendlyRedirect("", "Home", "Denied");
        }
    }
}