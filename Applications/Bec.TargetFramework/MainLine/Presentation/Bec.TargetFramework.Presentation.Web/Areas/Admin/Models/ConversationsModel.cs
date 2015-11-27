using Bec.TargetFramework.Entities.Enums;
using System;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Models
{
    public class ConversationsModel
    {
        public bool IsActivitySpecific { get; set; }
        public ActivityType ActivityType { get; set; }
        public Guid? SelectedConversationId { get; set; }
        public Guid CurrentUaoId { get; set; }
    }
}