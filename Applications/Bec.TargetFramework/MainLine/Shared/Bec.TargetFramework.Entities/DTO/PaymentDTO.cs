using Bec.TargetFramework.Entities.Helpers;
using Bec.TargetFramework.Entities.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    public class PaymentDTO
    {


        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public string PaymentDate { get; set; }

        [DataMember]
        public string CardType { get; set; }

        [DataMember]
        public string CardHolderName { get; set; }

        [DataMember]
        public string AuthCode { get; set; }

        [DataMember]
        public List<ShoppingCartItemDTO> CartItem { get; set; }

        [DataMember]
        public ShoppingCartDTO ShoppingCart { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public VUserAccountOrganisationDTO UserAccount { get; set; }

        [DataMember]
        public TransactionOrderPaymentDTO Response {get;set;}

    }


}

