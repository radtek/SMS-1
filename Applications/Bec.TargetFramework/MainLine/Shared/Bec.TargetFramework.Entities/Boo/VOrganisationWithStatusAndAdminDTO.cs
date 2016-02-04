using Bec.TargetFramework.Entities.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    public partial class VOrganisationWithStatusAndAdminDTO
    {
        [DataMember]
        public string Referrer { get; set; }
        [DataMember]
        public List<string> TradingNames { get; set; }

        [DataMember]
        public string BrokerTypeDescription{ get; set; }
        [DataMember]
        public string BrokerBusinessTypeDescription { get; set; }
    }
}
