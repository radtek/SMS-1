using Bec.TargetFramework.Entities;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bec.TargetFramework.Presentation.Web.Filters
{
    public class PersonalDetailsFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WebUserObject userObject = filterContext.HttpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] as WebUserObject;
            if (userObject != null && userObject.NeedsPersonalDetails)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Area", "Account" }, { "Controller", "PersonalDetails" }, { "Action", "Index" } });

            if (userObject != null && userObject.NeedsMobileNumber)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Area", "Account" }, { "Controller", "PersonalDetails" }, { "Action", "AddMobileNumber" } });
            base.OnActionExecuting(filterContext);
        }
    }
}