using System;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class NotificationContentDTO
    {
        [DataMember]
        public byte[] Content { get;set;}
        [DataMember]
        public DateTime DateSent { get; set; }
        [DataMember]
        public string NotificationSubject { get; set; }
    }
}
