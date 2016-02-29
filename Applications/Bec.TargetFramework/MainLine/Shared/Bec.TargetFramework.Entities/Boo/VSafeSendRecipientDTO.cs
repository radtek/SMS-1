
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class VSafeSendRecipientDTO
    {
        [DataMember]
        public string Hash { get; set; }
    }
}
