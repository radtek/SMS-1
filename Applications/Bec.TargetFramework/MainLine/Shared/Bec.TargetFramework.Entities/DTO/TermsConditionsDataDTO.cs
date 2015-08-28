using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    public class TermsConditionsDataDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid NotificationId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string VerificationCode { get; set; }
        [DataMember]
        public string UsersVerificationData { get; set; }

    }
}
