using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class AddCompanyDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Line1 { get; set; }
        [DataMember]
        public string Line2 { get; set; }
        [DataMember]
        public string AdditionalAddressInformation { get; set; }
        [DataMember]
        public string Town { get; set; }
        [DataMember]
        public string County { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string OrganisationAdminSalutation { get; set; }
        [DataMember]
        public string OrganisationAdminFirstName { get; set; }
        [DataMember]
        public string OrganisationAdminLastName { get; set; }
        [DataMember]
        public string OrganisationAdminTelephone { get; set; }
        [DataMember]
        public string OrganisationAdminEmail { get; set; }
        [DataMember]
        public string Regulator { get; set; }
        [DataMember]
        public string RegulatorOther { get; set; }
    }
}