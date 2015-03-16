using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Web.Framework.Helpers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Helpers;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Framework.Infrastructure;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;

namespace Bec.TargetFramework.UI.Process.Filters
{
    public class AuditActionFilter : ActionFilterAttribute
    {
        //Our value to handle our AuditingLevel
        public int AuditingLevel { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;

            var webUser = WebUserHelper.GetWebUserObject(filterContext.HttpContext);

            if (webUser != null)
            {
                var baseController = (ApplicationControllerBase)filterContext.Controller;

                //TODO Need to provide ChannelFactory for this
                var auditLogic = EngineContext.Current.Resolve<IUserAccountAuditLogic>();

                auditLogic.CreateAndSaveAudit(webUser, SerializeRequest(request));
            }

            base.OnActionExecuting(filterContext);
        }

        //This will serialize the Request object based on the level that you determine
        private string SerializeRequest(HttpRequestBase request)
        {
            switch (AuditingLevel)
            {
                //No Request Data will be serialized
                case 0:
                default:
                    return "";
                //Basic Request Serialization - just stores Data
                case 1:
                    return Json.Encode(new { request.Cookies, request.Headers, request.Files });
                //Middle Level - Customize to your Preferences
                case 2:
                    return Json.Encode(new { request.Cookies, request.Headers, request.Files, request.Form, request.QueryString, request.Params });
                //Highest Level - Serialize the entire Request object
                case 3:
                    //We can't simply just Encode the entire request string due to circular references as well
                    //as objects that cannot "simply" be serialized such as Streams, References etc.
                    //return Json.Encode(request);
                    return Json.Encode(new { request.Cookies, request.Headers, request.Files, request.Form, request.QueryString, request.Params });
            }
        }
    }
}
