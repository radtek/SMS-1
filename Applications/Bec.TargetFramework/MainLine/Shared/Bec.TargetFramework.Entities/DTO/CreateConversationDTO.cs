using Bec.TargetFramework.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class CreateConversationDTO
    {
        public ActivityType ActivityType { get; set; }
        public Guid ActivityId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<Guid> RecipientUaoIds { get; set; }
        public Guid AttachmentsID { get; set; }
    }
}
