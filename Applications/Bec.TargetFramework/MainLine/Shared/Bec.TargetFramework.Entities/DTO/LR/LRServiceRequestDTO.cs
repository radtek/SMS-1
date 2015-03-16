using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class LRServiceRequestDTO
    {
        [DataMember]
        public string MessageID { get; set; }
        [DataMember]
        public string CustomerReference { get; set; }
        [DataMember]
        public string ExternalReference { get; set; }
    }
}
