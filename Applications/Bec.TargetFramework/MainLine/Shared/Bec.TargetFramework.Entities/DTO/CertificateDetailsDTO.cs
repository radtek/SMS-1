using System;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    public class CertificateDetailsDTO
    {
        [DataMember]
        public string OrganisationName { get; set; }
        [DataMember]
        public int SchemeID { get; set; }
        [DataMember]
        public string StartDate { get; set; }
        [DataMember]
        public string BankAccountName { get; set; }
        [DataMember]
        public string BankAddress { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string SortCode { get; set; }
    }
}
