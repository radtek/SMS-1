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

        [DataMember]
        public string BankAccountStatus
        {
            get
            {
                if (ActiveSafeAccounts > 0) 
                {
                    return "Approved";
                }
                else if (PendingValidationAccounts > 0) 
                {
                    return "Submitted";
                }
                else
                {
                    return "None";
                }
            }
        }
    }
}
