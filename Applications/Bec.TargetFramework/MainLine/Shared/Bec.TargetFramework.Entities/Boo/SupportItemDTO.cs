
using System;
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class SupportItemDTO
    {
        [DataMember]
        public Guid AttachmentsID { get; set; }
    }
}
