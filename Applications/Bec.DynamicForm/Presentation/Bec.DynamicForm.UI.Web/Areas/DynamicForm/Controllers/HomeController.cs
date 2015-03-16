using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC;


using Bec.DynamicForm.Infrastructure.Log;

namespace Bec.TargetFramework.UI.Web.Areas.Admin.Controllers
{
    public class HomeController 
    {
       
        //
        // GET: /Admin/Home/
        [Authorize]
        public ActionResult Index(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "Index",
                RenderMode = RenderMode.AddTo,
                ContainerId = containerId,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

           

            return result;
        }
	}
}