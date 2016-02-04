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
        public Guid SroUaoID { get; set; }
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
        public string SroSalutation { get; set; }
        [DataMember]
        public string SroFirstName { get; set; }
        [DataMember]
        public string SroLastName { get; set; }
        [DataMember]
        public string SroEmail { get; set; }
        public string OrganisationType { get; set; }
    }
}