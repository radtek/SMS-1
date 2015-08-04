using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class InternalNotificationsAlertController : ApplicationControllerBase
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public PartialViewResult LatestNotifications()
        {
            var userId = WebUserHelper.GetWebUserObject(HttpContext).UserID;
            var model = NotificationLogicClient.GetLatestInternal(userId, 20);

            return PartialView("_LatestNotifications", model);
        }
    }
}