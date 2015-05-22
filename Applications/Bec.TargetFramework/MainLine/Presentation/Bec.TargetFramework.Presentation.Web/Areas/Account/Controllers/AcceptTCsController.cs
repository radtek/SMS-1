using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class AcceptTCsController : Controller
    {
        INotificationLogicClient m_NotificationLogicClient;
        public AcceptTCsController(INotificationLogicClient nClient)
        {
            m_NotificationLogicClient = nClient;
        }

        public ActionResult Index()
        {
            var userObject = Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] as WebUserObject;
            var result = m_NotificationLogicClient.GetTcAndCsText(userObject.UserID);
            ViewBag.NotificationID = result.NotificationID;
            ViewBag.NotificationConstructID = result.NotificationConstructID;
            ViewBag.NotificationConstructVersionNumber = result.NotificationConstructVersionNumber;
            ViewBag.Lines = result.Lines;
            return View(Guid.Empty);
        }

        public ActionResult GetPDF(Guid ncID, int version)
        {
            var userObject = Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] as WebUserObject;
            return File(m_NotificationLogicClient.GetTcAndCsData(ncID, version), "application/pdf", "TermsAndConditions.pdf");
        }

        [HttpPost]
        public ActionResult Done(Guid notificationID)
        {
            //mark as read: update session
            WebUserObject userObject = HttpContext.Session[WebUserHelper.m_WEBUSEROBJECTSESSIONKEY] as WebUserObject;
            if (userObject != null) userObject.NeedsTCs = false;

            //update database
            m_NotificationLogicClient.MarkAccepted(notificationID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}