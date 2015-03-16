using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class CartItemPriceDTO
    {
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public decimal UnitTotal { get; set; }
    }
}
