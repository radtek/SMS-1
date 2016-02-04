using Autofac;
using Autofac.Integration.Mvc;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Filters
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
            if (filterContext.HttpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] != null)
            {
                AutofacDependencyResolver resolver = DependencyResolver.Current as AutofacDependencyResolver;
                var container = resolver.ApplicationContainer;
                var logic = container.Resolve<IUserLogicClient>();
                var webUser = WebUserHelper.GetWebUserObject(filterContext.HttpContext);
                var logins = logic.UserLoginSessions(webUser.UserID);

                if (logins.Any(sessionID => sessionID.Equals(webUser.SessionIdentifier)))
                {
                    // check to see if your user ID is being used elsewhere under a different session ID
                    if (!logins.Any(sessionID => !sessionID.Equals(webUser.SessionIdentifier)))
                    {
                        base.OnActionExecuting(filterContext);
                    }
                    else
                    {
                        // if it is being used elsewhere, update all their Logins records to LoggedIn = false, except for your session ID
                        logic.LogEveryoneElseOut(webUser.UserID, webUser.SessionIdentifier);
                        base.OnActionExecuting(filterContext);
                    }
                }
                else
                {
                    // logout
                    filterContext.JsonFriendlyRedirect(action: "LoggedOutByAnother");
                }
            }
            else
            {
                if (filterContext.HttpContext.Request.RawUrl == "/" || filterContext.HttpContext.Request.RawUrl == "/home/index")
                    filterContext.JsonFriendlyRedirect(action: "Index");
                else
                    filterContext.JsonFriendlyRedirect();
            }
        }
    }
}