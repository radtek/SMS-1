using Bec.TargetFramework.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class OrganisationBankAccountStateChangeDTO
    {
        [DataMember]
        public Guid OrganisationID { get; set; }
        [DataMember]
        public Guid BankAccountID { get; set; }
        [DataMember]
        public Guid ChangedByUserAccountOrganisationID { get; set; }
        [DataMember]
        public BankAccountStatusEnum BankAccountStatus { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public string DetailsUrl { get; set; }
    }
} 
