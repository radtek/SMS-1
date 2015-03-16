using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.DTO.Notification
{
    [Serializable]
    [DataContract]
    public class UserNextStepsNotificationDTO
    {
        [DataMember]
        public decimal SafeTransactionSearchPublicProductPrice { get;set;}

        [DataMember]
        public decimal IDCheckProductPrice { get; set; }

        [DataMember]
        public decimal TitleDocumentProductPrice { get; set; }

        [DataMember]
        public string STSandDataLink { get; set; }
    }
}
