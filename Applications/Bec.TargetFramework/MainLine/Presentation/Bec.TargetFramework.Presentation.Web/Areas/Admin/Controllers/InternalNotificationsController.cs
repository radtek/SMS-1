using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class InternalNotificationsController : ApplicationControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadNotifications()
        {
            var data = Enumerable.Range(1, 40).Select(n =>
                new VNotificationInternalUnreadDTO
                {
                    NotificationID = Guid.NewGuid(),
                    Name = "Notification " + n + " firm X marked the account Y as suspicious fraud.",
                    DateSent = DateTime.Now.AddMinutes(n * (-2))
                });
                //new NotificationEntry
                //{
                //    NotificationID = Guid.NewGuid(),
                //    NotificationSubject = "Notification " + n + " firm X marked the account Y as suspicious fraud.",
                //    DateSent = DateTime.Now.AddMinutes(n * (-2))
                //});

            var jsonData = new { total = data.Count(), data };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }

    public class NotificationEntry
    {
        public Guid NotificationID { get; set; }
        public string NotificationSubject { get; set; }
        public DateTime DateSent { get; set; }

    }
}