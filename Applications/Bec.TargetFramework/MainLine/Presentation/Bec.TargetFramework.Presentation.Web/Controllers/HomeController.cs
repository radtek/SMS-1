using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Presentation.Web.Base;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class HomeController : ApplicationControllerBase
    {
        public HomeController(ILogger logger) : base(logger)
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewCancel()
        {
            return PartialView("_Cancel");
        }
    }
}