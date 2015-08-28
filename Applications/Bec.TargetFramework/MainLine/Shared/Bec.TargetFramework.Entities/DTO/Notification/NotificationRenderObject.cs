using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    public class NotificationRenderObjectDTO
    {
         [DataMember]
        public byte[] BusinessObjectContent { get; set; }
         [DataMember]
        public string BusinessObjectTypeName { get; set; }
         [DataMember]
        public string BusinessObjectCategoryName { get; set; }
         [DataMember]
        public string BusinessObjectName { get; set; }
    }
}
