using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Bec.TargetFramework.Entities
{
    using Bec.TargetFramework.Framework.Configuration;
    using Ext.Net;
    using Fabrik.Common;

    [Serializable]
    [DataContract]
    public class NotificationRenderDTO
    {
        [DataMember]
        public NotificationConstructDTO NotificationConstructDTO { get; set; }
        [DataMember]
        public byte[] ReportTemplate { get; set; }
         [DataMember]
        public string json { get; set; }
       [DataMember]
        public List<NotificationRenderObjectDTO> BusinessObjects { get; set; } 
    }
}
