using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    public partial class VConversationDTO
    {
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string LinkDescription { get; set; }
        [DataMember]
        public bool Unread { get; set; }
    }

    [Serializable]
    public class ConversationResultDTO<T>
    {
        public long Count { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
