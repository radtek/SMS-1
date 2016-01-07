using Bec.TargetFramework.Entities.Enums;
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
        public OrganisationTypeEnum OrganisationType { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string TradingName { get; set; }
        [DataMember]
        public string Line1 { get; set; }
        [DataMember]
        public string Line2 { get; set; }
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
        [DataMember]
        public OrganisationRecommendationSource? OrganisationRecommendationSource { get; set; }

        //broker specific
        [DataMember]
        public BrokerTypeEnum? BrokerType { get; set; }
        [DataMember]
        public BrokerBusinessTypeEnum? BrokerBusinessType { get; set; }
    }
}