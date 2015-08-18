using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
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

        private string GetNotificationContent(Guid notificationId)
        {
            var userAccountOrganisationId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var notificationByteArray = NotificationLogicClient.GetNotificationContent(notificationId, userAccountOrganisationId);
            var notificationHtml = Encoding.UTF8.GetString(notificationByteArray);

            return notificationHtml;
        }
    }
}