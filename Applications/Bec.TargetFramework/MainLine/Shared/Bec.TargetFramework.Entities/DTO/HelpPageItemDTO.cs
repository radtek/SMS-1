using System;
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{    
    public partial class HelpPageItemDTO
    {
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public Guid[] RoleId { get; set; }
    }
}
