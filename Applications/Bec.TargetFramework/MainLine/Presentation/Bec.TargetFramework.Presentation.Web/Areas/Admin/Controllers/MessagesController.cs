using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesController : ApplicationControllerBase
    {
        public INotificationLogicClient NotificationClient { get; set; }

        public ActionResult Index()
        {
            return View(GetDummyDiscussions());
        }

        private List<Discussion> GetDummyDiscussions()
        {
            return new List<Discussion>
            {
                new Discussion
                { 
                    Subject = "New property to buy",
                    FirstUnreadCreatedOn = DateTime.Now,
                    FirstUnreadUser = "Edward Powell",
                    FirstUnreadMessage = "You should have done it before!",
                    IsUnread = true,
                },
                new Discussion
                { 
                    Subject = "Concerns about the survery",
                    FirstUnreadCreatedOn = DateTime.Now,
                    FirstUnreadUser = "Sam Johns",
                    FirstUnreadMessage = "How dear you?",
                    IsUnread = true,
                },
                new Discussion
                { 
                    Subject = "The contract has to be signed",
                    FirstUnreadCreatedOn = DateTime.Now,
                    FirstUnreadUser = "Bob Smith",
                    FirstUnreadMessage = "Ok!",
                    IsUnread = false,
                },
                new Discussion
                { 
                    Subject = "Whatever else",
                    FirstUnreadCreatedOn = DateTime.Now,
                    FirstUnreadUser = "Bob Smith",
                    FirstUnreadMessage = "You should have done it before!",
                    IsUnread = false,
                },
                new Discussion
                { 
                    Subject = "Very long subject Very long subject Very long subject Very long subject Very long subject Very long subject Very long subject Very long subject",
                    FirstUnreadCreatedOn = DateTime.Now,
                    FirstUnreadUser = "Edward Powell",
                    FirstUnreadMessage = "Very long content Very long content Very long content Very long content",
                    IsUnread = false,
                },
            };
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

    public class MessagesModel
    {
        public List<Discussion> Discussions { get; set; }
        public bool IsCompactView { get; set; }
    }

    public class Discussion
    {
        public string Subject { get; set; }
        public DateTime FirstUnreadCreatedOn { get; set; }
        public string FirstUnreadUser { get; set; }
        public string FirstUnreadMessage { get; set; }
        public bool IsUnread { get; set; }
    }
}