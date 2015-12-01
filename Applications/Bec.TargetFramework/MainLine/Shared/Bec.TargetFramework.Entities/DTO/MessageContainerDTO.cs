using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class MessageContainerDTO
    {
        public IEnumerable<MessageDTO> Messages { get; set; }
        public IEnumerable<ParticipantDTO> Participants { get; set; }
    }
}
