using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.App_Helpers;
using Bec.TargetFramework.Presentation.Web.Base;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class InternalNotificationsController : ApplicationControllerBase
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid notificationId)
        {
            string notificationHtml;
            try
            {
                notificationHtml = GetNotificationContent(notificationId);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
            ViewBag.NotificationId = notificationId;
            return View((object)notificationHtml);
        }

        public JsonResult LoadNotifications()
        {
            var userAccountOrganisationId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var model = NotificationLogicClient.GetInternal(userAccountOrganisationId);

            var jsonData = new { total = model.Count(), data = model };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNotification(Guid notificationId)
        {
            var notificationHtml = GetNotificationContent(notificationId);
            return Json(new { data = notificationHtml }, JsonRequestBehavior.AllowGet);
        }

        public PdfContentResult ExportToPdf(Guid notificationId)
        {
            var userAccountOrganisationId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var notificationContent = NotificationLogicClient.GetNotificationContent(notificationId, userAccountOrganisationId, NotificationExportFormatIDEnum.PDF);

            return new PdfContentResult
            {
                FileContents = notificationContent.Content,
                FileDownloadName = string.Format("Notification_{0}_{1}.pdf", notificationContent.NotificationSubject, notificationContent.DateSent.ToShortDateString())
            };
        }

        private string GetNotificationContent(Guid notificationId)
        {
            var userAccountOrganisationId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var notificationContent = NotificationLogicClient.GetNotificationContent(notificationId, userAccountOrganisationId, NotificationExportFormatIDEnum.HTML);
            var notificationHtml = Encoding.UTF8.GetString(notificationContent.Content);

            return notificationHtml;
        }
    }
}