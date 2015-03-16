using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    public class TreeStructureVisibilityDTO
    {
        [DataMember]
        public bool IAmCO { get; set; }
        [DataMember]
        public bool Editable { get; set; }
        [DataMember]
        public bool PaymentWithPreAuth { get; set; }

        [DataMember]
        public bool IsPaymentSuccessful { get; set; }
    }
}
