
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class FnGetConversationActivityResultDTO
    {
        [DataMember]
        public bool Unread { get; set; }
    }
}
