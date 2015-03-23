using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class HomeController : ApplicationControllerBase
    {
        public HomeController(ILogger logger) : base(logger)
        { }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}