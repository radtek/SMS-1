using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC;
using Ext.Net;

namespace Bec.TargetFramework.UI.Web.Areas.SafeMoveScheme.Controllers
{
    public class ProfessionalController : Controller
    {
        //
        // GET: /SafeMoveScheme/Professional/
        public ActionResult Home()
        {
            return View();

        }
        //public ActionResult Index()
        //{
        //    return RedirectToAction("Index", "Default", new { area = "SafeMoveScheme" });
        //}

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Press()
        {
            return View();

        }

        public ActionResult Professionals()
        {
            return View();

        }

        public ActionResult HomeProfessional()
        {
            return RedirectToAction("Home", "Professional", new { area = "SafeMoveScheme" });
        }

        //public ActionResult ProfessionalsProfessional()
        //{
        //    return RedirectToAction("Professionals", "Professional", new { area = "SafeMoveScheme" });
        //}

        //public ActionResult AboutProfessional()
        //{
        //    return RedirectToAction("About", "Professional", new { area = "SafeMoveScheme" });
        //}

        //public ActionResult PressProfessional()
        //{
            
        //    return RedirectToAction("Press", "Professional", new { area = "SafeMoveScheme" });
        //}

        public ActionResult LoadPartial(string partialName,string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = partialName,
                RenderMode = RenderMode.AddTo,
                ClearContainer = true,
                ContainerId = containerId,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            return result;
        }

       
	}
}