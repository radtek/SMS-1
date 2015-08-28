using System;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class OrganisationBankAccountAddStatusDTO
    {
        [DataMember]
        public Guid OrganisationID { get; set; }
        [DataMember]
        public Guid BankAccountID { get; set; }
        [DataMember]
        public Guid? BankAccountOrganisationID { get; set; }
        [DataMember]
        public Guid StatusTypeID { get; set; }
        [DataMember]
        public int StatusTypeVersionNumber { get; set; }
        [DataMember]
        public Guid StatusTypeValueID { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public bool WasActive { get; set; }
    }
}
