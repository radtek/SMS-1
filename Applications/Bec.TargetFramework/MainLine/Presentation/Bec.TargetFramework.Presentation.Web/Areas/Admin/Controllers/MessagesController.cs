using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.App_Helpers;
using Bec.TargetFramework.Presentation.Web.Base;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesController : ApplicationControllerBase
    {
        public INotificationLogicClient NotificationClient { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public async Task Create(Guid uaoID, ActivityType? activityTypeID, Guid? activityID, string subject, string message, Guid[] participantsUaoIDs)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await NotificationClient.CreateConversationAsync(orgID, uaoID, activityTypeID, activityID, subject, message, participantsUaoIDs);
        }

        public async Task Reply(Guid uaoID, Guid conversationID, string message)
        {
            await NotificationClient.ReplyToConversationAsync(uaoID, conversationID, message);
        }
    }

    public class Discussion
    {
        public string Subject { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FirstUnreadUser { get; set; }
        public string FirstUnreadMessage { get; set; }
    }

}