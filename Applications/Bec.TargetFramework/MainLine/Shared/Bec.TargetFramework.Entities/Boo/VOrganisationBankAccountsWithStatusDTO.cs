
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class VOrganisationBankAccountsWithStatusDTO
    {
        [DataMember]
        public List<OrganisationBankAccountStatusDTO> History { get; set; }
    }
}
