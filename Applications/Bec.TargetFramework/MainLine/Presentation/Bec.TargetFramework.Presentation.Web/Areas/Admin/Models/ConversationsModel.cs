using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Models
{
    public class ConversationsModel
    {
        public bool IsActivitySpecific { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}