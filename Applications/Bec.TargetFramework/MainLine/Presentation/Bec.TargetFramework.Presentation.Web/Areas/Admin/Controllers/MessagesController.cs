﻿using Bec.TargetFramework.Presentation.Web.Base;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesController : ApplicationControllerBase
    {
        public ActionResult Index()
        {
            return View(GetDummyDiscussions());
        }

        private System.Collections.Generic.List<Discussion> GetDummyDiscussions()
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