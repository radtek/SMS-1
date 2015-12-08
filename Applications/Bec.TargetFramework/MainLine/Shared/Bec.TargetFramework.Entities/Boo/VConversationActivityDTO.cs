
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class VConversationActivityDTO
    {
        [DataMember]
        public bool Unread { get; set; }
    }
}
