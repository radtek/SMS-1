using Bec.TargetFramework.Entities.Enums;
using System;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class VerifyCompanyDTO
    {
        [DataMember]
        public Guid OrganisationID { get; set; }
        [DataMember]
        public Guid UaoID { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string OrganisationName { get; set; }
        [DataMember]
        public int? FilesPerMonth { get; set; }
        [DataMember]
        public string RegulatorName { get; set; }
        [DataMember]
        public string RegulatorNumber { get; set; }
        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        public string OrganisationType { get; set; }
        [DataMember]
        public bool IsAuthorityDelegated { get; set; }
        [DataMember]
        public string AuthorityDelegatedToSalutation { get; set; }
        [DataMember]
        public string AuthorityDelegatedToFirstName { get; set; }
        [DataMember]
        public string AuthorityDelegatedToLastName { get; set; }
        [DataMember]
        public string AuthorityDelegatedToEmail { get; set; }
    }
}