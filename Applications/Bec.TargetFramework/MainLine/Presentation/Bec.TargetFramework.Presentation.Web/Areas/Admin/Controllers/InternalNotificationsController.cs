using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using System.Linq;
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

        public JsonResult LoadNotifications()
        {
            var userId = WebUserHelper.GetWebUserObject(HttpContext).UserID;
            var model = NotificationLogicClient.GetUnreadNotifications(userId, NotificationConstructEnum.All);

            var jsonData = new { total = model.Count(), data = model };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}