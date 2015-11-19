using Bec.TargetFramework.Presentation.Web.Base;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesPartialController : ApplicationControllerBase
    {
        public PartialViewResult AllMessages(bool isCompactView)
        {
            var model = new MessagesModel
            {
                Discussions = GetDummyDiscussions(),
                IsCompactView = isCompactView
            };

            return PartialView("_AllMessages", model);
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
    }
}