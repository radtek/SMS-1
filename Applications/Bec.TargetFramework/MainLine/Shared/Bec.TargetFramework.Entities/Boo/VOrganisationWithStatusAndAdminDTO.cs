
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    public partial class VOrganisationWithStatusAndAdminDTO
    {
        [DataMember]
        public string Referrer { get; set; }
    }
}
