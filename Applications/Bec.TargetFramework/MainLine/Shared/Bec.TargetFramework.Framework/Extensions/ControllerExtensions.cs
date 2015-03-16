using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ext.Net;

namespace Bec.TargetFramework.Web.Framework.Extensions
{
    public static class ControllerExtensions
    {
        public static string AbsoluteAction(this UrlHelper url,
    string actionName, string controllerName, object routeValues = null)
        {
            string scheme = url.RequestContext.HttpContext.Request.Url.Scheme;

            return url.Action(actionName, controllerName, routeValues, scheme);
        }

        public static Ext.Net.MVC.PartialViewResult CreatePartialViewResult(this Controller control, string viewName,
            string containerId,
            object model = null)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = viewName,
                RenderMode = RenderMode.AddTo,
                Model = model,
                ClearContainer = true,
                ContainerId = containerId,
                WrapByScriptTag = false
                // we load the view via Loader with Script mode therefore script tags is not required
            };

            return result;
        }
    }
}
