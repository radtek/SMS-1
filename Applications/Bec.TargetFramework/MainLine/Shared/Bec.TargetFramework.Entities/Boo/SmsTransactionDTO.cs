using System.Linq;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    public partial class SmsTransactionDTO
    {
        [DataMember]
        public string OrganisationName
        {
            get
            {
                var orgName = string.Empty;
                if (Organisation != null && Organisation.OrganisationDetails != null && Organisation.OrganisationDetails.Any())
                {
                    orgName = Organisation.OrganisationDetails.First().Name;
                }
                return orgName;
            }
        }
    }
}
