
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class OrganisationBankAccountStatusDTO
    {
        [DataMember]
        public string StatusName { get; set; }
    }
}
