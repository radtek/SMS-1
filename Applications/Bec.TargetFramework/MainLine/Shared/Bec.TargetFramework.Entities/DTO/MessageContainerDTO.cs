using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class MessageContainerDTO
    {
        public bool IsCurrentUserParticipant { get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }
        public IEnumerable<ParticipantDTO> Participants { get; set; }
    }
}
