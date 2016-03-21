
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class HelpDTO
    {
        [DataMember]
        public string CreatedByName { get; set; }
        [DataMember]
        public string ModifiedByName { get; set; }
    }
}
