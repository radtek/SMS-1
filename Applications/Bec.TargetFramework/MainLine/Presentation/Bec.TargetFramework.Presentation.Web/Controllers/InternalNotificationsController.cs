using Bec.TargetFramework.Presentation.Web.Base;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class InternalNotificationsController : ApplicationControllerBase
    {
        public PartialViewResult LatestNotifications()
        {
            return PartialView("_LatestNotifications");
        }
    }
}