﻿using Bec.TargetFramework.Business.Client.Interfaces;
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
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var unreadCount = NotificationLogicClient.GetUnreadConversationsCount(uaoId);
            return PartialView("_LatestConversationsContainer", unreadCount);
        }

        public PartialViewResult LatestConversations()
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var model = NotificationLogicClient.GetLatestUnreadConversations(uaoId, 20);

            return PartialView("_LatestConversations", model);
        }
    }
}