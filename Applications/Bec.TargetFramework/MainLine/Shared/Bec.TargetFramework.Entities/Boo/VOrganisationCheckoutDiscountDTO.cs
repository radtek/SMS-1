
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    public partial class VOrganisationCheckoutDiscountDTO
    {
        [DataMember]
        public DiscountDTO DiscountDto { get; set; }
    }
}
