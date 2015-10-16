using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    public partial class OrganisationDetailDTO
    {
        [DataMember]
        public string DisplayName 
        {
            get
            {
                return string.IsNullOrWhiteSpace(TradingName) 
                    ? Name 
                    : TradingName;
            }
        }
    }
}
