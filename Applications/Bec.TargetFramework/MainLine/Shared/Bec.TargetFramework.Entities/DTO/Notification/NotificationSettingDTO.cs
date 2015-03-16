using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    using Ext.Net;

    [Serializable]
    [DataContract]
    public class NotificationSettingDTO
    {
        [DataMember]
        public string ServerURL { get; set; }
        [DataMember]
        public string ServerNotificationImageContentURLFolder { get; set; }
        [DataMember]
        public string ServerLogoImageFileNameWithExtension { get; set; }
        [DataMember]
        public Guid NotificiationSentFromParentID { get; set; }
        [DataMember]
        public Guid NotificationConstructID { get; set; }
        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }
        [DataMember]
        public int? ExportFormat { get; set; }
         [DataMember]
        public string LoginRoute { get; set; }
        [DataMember]
         public string Subject { get; set; }
        [DataMember]
         public string Title { get; set; }
         [DataMember]
        public string NotificationFromEmailAddress { get; set; }
    }
}
