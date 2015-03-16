using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Services;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;

namespace Bec.TargetFramework.UI.Web.Controllers
{
    public class HomeController : ApplicationControllerBase
    {
        public HomeController(ILogger logger)
            : base(logger)
        {
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "STSLogin" });
        }
    }
}