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
        public List<string> RecipientHashes { get; set; }
        public Guid AttachmentsID { get; set; }
        public string FromHash { get; set; }
    }

    public class CreateConversationRecipientDTO
    {
        public Guid OrganisationID { get; set; }
        public Guid Value { get; set; }
        public bool IsSafeSendGroup { get; set; }

        public string Display { get; set; }
        public string Hash { get; set; }
    }
}
