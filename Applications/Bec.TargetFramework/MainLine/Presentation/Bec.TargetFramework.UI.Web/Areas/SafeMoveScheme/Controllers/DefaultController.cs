using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ext.Net.MVC;
using Ext.Net;

namespace Bec.TargetFramework.UI.Web.Areas.SafeMoveScheme.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /SafeMoveScheme/Default/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Terms()
        {
            return View();
        }
                
	}
}