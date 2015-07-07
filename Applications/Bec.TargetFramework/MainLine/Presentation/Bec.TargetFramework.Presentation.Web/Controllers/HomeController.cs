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
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Denied()
        {
            return View("Denied");
        }


        public ActionResult ViewCancel()
        {
            return PartialView("_Cancel");
        }

        public ActionResult ViewMessage(string title, string message, string button)
        {
            ViewBag.title = title;
            ViewBag.message = message;
            ViewBag.button = button;
            return PartialView("_Message");
        }

        public async Task<ActionResult> ViewResendLogins(Guid uaoId, string label, string redirectAction, string redirectController, string redirectArea)
        {
            ViewBag.orgId = uaoId;
            ViewBag.label = label;
            ViewBag.RedirectAction = redirectAction;
            ViewBag.RedirectController = redirectController;
            ViewBag.RedirectArea = redirectArea;
            return PartialView("_ResendLogins");
        }
    }
}