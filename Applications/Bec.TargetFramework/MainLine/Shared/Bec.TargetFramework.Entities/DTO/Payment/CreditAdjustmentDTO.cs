using System;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    public class CreditAdjustmentDTO
    {
        [DataMember]
        public Guid OrganisationId { get; set; }
        [DataMember]
        public Guid UserAccountOrganisationId { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string DetailsUrlFormat { get; set; }
    }
}
