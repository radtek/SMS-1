using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Bec.TargetFramework.Entities.DTO.Event
{
    [Serializable]
    [DataContract]
    public class EventPayloadDTO
    {
        [DataMember]
        public string EventReference { get; set; }

        [DataMember]
        public Guid EventID { get; set; }
        [DataMember]
        public string EventName { get; set; }
        [DataMember]
        public Guid EventType { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string EventSource { get; set; }
        [DataMember]
        public byte[] Payload { get; set; }
        [DataMember]
        public string PayloadObjectType { get; set; }

    }
}
