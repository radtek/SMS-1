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
    public class InformationDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

         [DataMember]
        public string InvoiceName { get; set; }

         [DataMember]
         public decimal ValueComponent { get; set; }

         [DataMember]
         public decimal PercentageComponent { get; set; }

         [DataMember]
         public decimal PriceAdjustmentAmount { get; set; }
    }
}
