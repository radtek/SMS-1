using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class InternalNotificationsAlertController : ApplicationControllerBase
    {
        public PartialViewResult LatestNotifications()
        {
            var data = Enumerable.Range(1, 20).Select(n =>
                new VNotificationInternalUnreadDTO
                {
                    NotificationID = Guid.NewGuid(),
                    Name = "Notification " + n + " firm X marked the account Y as suspicious fraud.",
                    DateSent = DateTime.Now.AddMinutes(n * (-2))
                }).ToList();

            return PartialView("_LatestNotifications", data);
        }
    }
}