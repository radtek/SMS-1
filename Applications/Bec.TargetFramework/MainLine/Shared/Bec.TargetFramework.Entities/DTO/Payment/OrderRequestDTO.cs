using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bec.TargetFramework.Entities.Helpers;
using System.Text.RegularExpressions;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Entities
{
    //[FluentValidation.Attributes.ValidatorAttribute(typeof(OrderRequestDTOValidator))]
    [Serializable]
    [DataContract]
    public partial class OrderRequestDTO
    {
        [DataMember]
        public string CardNumber { get; set; }

        [DataMember]
        public int CardExpiryMonth { get; set; }

        [DataMember]
        public int CardExpiryYear { get; set; }
        [DataMember]
        public int CVVNumber { get; set; }

        [DataMember]
        public PaymentChargeTypeEnum PaymentChargeType { get; set; }

        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string Line1 { get; set; }
        [DataMember]
        public string Line2 { get; set; }
        [DataMember]
        public string Town { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string County { get; set; }

        [DataMember]
        public Guid TransactionOrderID { get; set; }
    }


}
