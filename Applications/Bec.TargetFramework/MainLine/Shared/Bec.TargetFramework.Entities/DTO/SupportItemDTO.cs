using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    public partial class SupportItemDTO
    {
        [DataMember]
        public Guid AttachmentsID { get; set; }
    }
}
