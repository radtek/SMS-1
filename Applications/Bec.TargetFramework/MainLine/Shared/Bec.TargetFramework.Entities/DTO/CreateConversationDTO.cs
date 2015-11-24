using Bec.TargetFramework.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class CreateConversationDTO
    {
        public ActivityType ActivityType { get; set; }
        public Guid? ActivityId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<Guid> ParticipantUaoIds { get; set; }
    }
}
