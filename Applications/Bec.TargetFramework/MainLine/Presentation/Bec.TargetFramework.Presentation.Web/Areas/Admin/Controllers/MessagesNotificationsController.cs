using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesNotificationsController : ApplicationControllerBase
    {
        public INotificationLogicClient NotificationLogicClient { get; set; }
        public PartialViewResult LatestConversationsContainer()
        {
            return PartialView("_LatestConversationsContainer");
        }

        public PartialViewResult LatestConversations()
        {
            var userAccountOrganisationId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var model = NotificationLogicClient.GetLatestUnreadConversations(userAccountOrganisationId, 20);

            return PartialView("_LatestConversations", model);
        }
    }
}