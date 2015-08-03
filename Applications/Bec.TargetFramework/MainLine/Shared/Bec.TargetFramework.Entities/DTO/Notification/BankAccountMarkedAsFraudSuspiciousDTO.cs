using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO.Notification
{
    [DataContract]
    public class BankAccountMarkedAsFraudSuspiciousDTO
    {
        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string SortCode { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string DetailsUrl { get; set; }
    }
}
