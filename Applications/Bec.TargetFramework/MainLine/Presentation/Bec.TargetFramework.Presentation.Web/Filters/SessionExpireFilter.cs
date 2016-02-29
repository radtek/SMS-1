﻿using Bec.TargetFramework.Entities;
using System;
using System.Security.Principal;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionExpireFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity) throw new InvalidOperationException("Windows Authentication is not supported");
            
            // If the browser session or authentication session has expired...
            if (filterContext.HttpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] == null || !filterContext.HttpContext.Request.IsAuthenticated)
                filterContext.JsonFriendlyRedirect();
                
            base.OnActionExecuting(filterContext);
        }
    }
}
