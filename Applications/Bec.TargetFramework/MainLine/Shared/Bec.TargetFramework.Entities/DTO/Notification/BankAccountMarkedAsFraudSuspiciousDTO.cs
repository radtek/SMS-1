using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO.Notification
{
    [DataContract]
    public class BankAccountMarkedAsFraudSuspiciousDTO
    {
        [DataMember]
        public string SortCode { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
    }
}
