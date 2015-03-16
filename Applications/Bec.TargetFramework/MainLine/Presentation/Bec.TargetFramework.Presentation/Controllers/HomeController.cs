using Bec.TargetFramework.UI.Process.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Controllers
{
    public class HomeController : ApplicationControllerBase
    {

        public HomeController(Bec.TargetFramework.Infrastructure.Log.ILogger logger)
            : base(logger)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order()
        {
            throw new ApplicationException();
            //return View();
        }

        public ActionResult Client()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }

        public ActionResult TestingDynamic()
        {
            return View();
        }

        public ActionResult TestLoadingView()
        {
            return View();
        }
    }
}