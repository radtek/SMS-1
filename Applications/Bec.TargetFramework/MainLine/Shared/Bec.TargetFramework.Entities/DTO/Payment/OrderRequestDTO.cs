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
using Bec.TargetFramework.Entities.Validators;

namespace Bec.TargetFramework.Entities
{
    [FluentValidation.Attributes.ValidatorAttribute(typeof(OrderRequestDTOValidator))]
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
        public decimal TotalExclTax { get; set; }

        [DataMember]
        public decimal Tax { get; set; }

        [DataMember]
        public decimal TotalInclTax { get; set; }

        [DataMember]
        public PaymentChargeTypeEnum PaymentChargeType { get; set; }


    }


}
