using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Web.Caching;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Repositories;
using Bec.TargetFramework.Data.Infrastructure;
using System.Web.Security;
using System.Web.Routing;
using Bec.TargetFramework.Web.Framework.Helpers;

namespace Bec.TargetFramework.UI.Process.Filters
{
    public class PreventMultipleLoginsActionFilter : ActionFilterAttribute
    {
        //This stores the time between Requests (in seconds)
        public int DelayRequest = 10;
        //The Error Message that will be displayed in case of excessive Requests
        public string ErrorMessage = "Excessive Request Attempts Detected.";
        //This will store the URL to Redirect errors to
        public string RedirectURL;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing))
            {
                var repos = scope.GetCustomRepository<UserAccountLoginSessionRepository>();

                if (filterContext.HttpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] != null)
                {
                    var webUser = WebUserHelper.GetWebUserObject(filterContext.HttpContext);

                    if (repos.IsUserLoginStillTrue(webUser.UserID, webUser.SessionIdentifier))
                    {
                        // check to see if your user ID is being used elsewhere under a different session ID
                        if (!repos.IsUserLoggedOnElsewhere(webUser.UserID, webUser.SessionIdentifier))
                        {
                            base.OnActionExecuting(filterContext);
                        }
                        else
                        {
                            // if it is being used elsewhere, update all their Logins records to LoggedIn = false, except for your session ID
                            repos.LogEveryoneElseOut(webUser.UserID, webUser.SessionIdentifier);

                            scope.Save();

                            base.OnActionExecuting(filterContext);
                        }
                    }
                    else
                    {
                        // logout
                        filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary { { "controller", "Logout" }, { "action", "Index" }, { "area", "UserAccount" } });
                    }
                }
                else
                    filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" }, { "area", "UserAccount" } });


            }
        }
    }

    public class UserAccountLogicHelper
    {
        public static void CreateUserAccountLoginLogEntry(HttpContextBase context, Guid userId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing))
            {
                var repos = scope.GetCustomRepository<UserAccountLoginSessionRepository>();

                var webUser = WebUserHelper.GetWebUserObject(context);

                repos.IsInScope = true;

                repos.SaveUserAccountLoginSession(userId, webUser.SessionIdentifier, context.Request.UserHostAddress, "", "");

                scope.Save();
            }

        }

    }
}