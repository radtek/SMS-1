
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class TransactionOrderDTO
    {

        [DataMember]
        public VUserAccountOrganisationDTO VUserAccountOrganisationDto { get; set; }
    }
}
