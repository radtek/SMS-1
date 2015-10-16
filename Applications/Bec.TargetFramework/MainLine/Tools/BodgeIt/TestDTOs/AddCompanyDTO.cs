using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodgeIt.TestDTOs
{
    public class AddCompanyDTO
    {
        [DataMember]
        public string CompanyName { get; set; }
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
        [DataMember]
        public string RegulatorNumber { get; set; }
        [DataMember]
        public bool Manual { get; set; }
    }
    public enum OrganisationTypeEnum : int
    {
        Administration = 30,
        Branch = 34,
        Personal = 29,
        Conveyancing = 28,
        Supplier = 33,
        Temporary = 27,
        Professional = 31
    }
}
