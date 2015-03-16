
using Bec.TargetFramework.Web.Framework.Helpers;
using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Thinktecture.IdentityModel;

namespace Bec.TargetFramework.Security
{
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Method,
        Inherited = true,
        AllowMultiple = true
    )]
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private string _action;
        private string[] _resources;

        private const string _label = "Bec.TargetFramework.Security.ClaimsAuthorizeAttribute";

        public ClaimsAuthorizeAttribute()
        { }

        public ClaimsAuthorizeAttribute(string action, params string[] resources)
        {
            _action = action;
            _resources = resources;
        }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Items[_label] = filterContext;
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            Ensure.Argument.NotNull(httpContext);

            // Authenticate the user using Forms Authentication
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }

            //  check that a new session has not been created, if we are missing
            // some critical session variables then we assume that the session
            // expired and do not allow the request to continue
            if (httpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] == null)
                return false;

            if (!string.IsNullOrWhiteSpace(_action))
            {
                return ClaimsAuthorization.CheckAccess(_action, _resources);
            }
            else
            {
                var filterContext = httpContext.Items[_label] as System.Web.Mvc.AuthorizationContext;
                return CheckAccess(filterContext);
            }
        }

        protected virtual bool CheckAccess(System.Web.Mvc.AuthorizationContext filterContext)
        {
            var action = filterContext.RouteData.Values["action"] as string;
            var controller = filterContext.RouteData.Values["controller"] as string;

            return ClaimsAuthorization.CheckAccess(action, controller);
        }
    }
}
