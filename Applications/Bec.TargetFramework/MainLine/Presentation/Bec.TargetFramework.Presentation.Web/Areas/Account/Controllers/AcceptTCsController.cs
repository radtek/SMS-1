using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class AcceptTCsController : Controller
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }

        public async Task<ActionResult> Index()
        {
            var userObject = WebUserHelper.GetWebUserObject(HttpContext);
            var result = await NotificationLogicClient.GetTcAndCsTextAsync(userObject.UserID);
            if (result == null)
            {
                userObject.NeedsTCs = false;
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            ViewBag.NotificationID = result.NotificationID;
            ViewBag.NotificationConstructID = result.NotificationConstructID;
            ViewBag.NotificationConstructVersionNumber = result.NotificationConstructVersionNumber;
            ViewBag.Lines = result.Lines;
            return View(Guid.Empty);
        }

        public async Task<ActionResult> GetPDF(Guid ncID, int version)
        {
            var userObject = WebUserHelper.GetWebUserObject(HttpContext);
            return File(await NotificationLogicClient.RetrieveNotificationConstructDataAsync(ncID, version, null), "application/pdf", "TermsAndConditions.pdf");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Done(Guid notificationID)
        {
            //mark as read: update session
            var userObject = WebUserHelper.GetWebUserObject(HttpContext);
            if (userObject != null) userObject.NeedsTCs = (await NotificationLogicClient.GetUnreadNotificationsAsync(userObject.UserID, new[] { NotificationConstructEnum.TcPublic, NotificationConstructEnum.TcFirmConveyancing })).Count > 0;

            //update database
            await NotificationLogicClient.MarkAcceptedAsync(notificationID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}