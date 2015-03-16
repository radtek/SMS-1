using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bec.TargetFramework.Entities.Helpers;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
     public partial class OrderResponseDTO
    {
        [DataMember]
        public string ApprovalCode { get; set; }

        [DataMember]
        public string AVSResponse { get; set; }
        [DataMember]
        public bool IsTransactionSuccessful { get; set; }
        [DataMember]
        public string TransactionResult { get; set; }
        [DataMember]
        public string TransactionTime { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public string CardBrand { get; set; }
        [DataMember]
        public string FirstDataResponseData { get; set; }
        [DataMember]
        public string ProcessorResponseCode { get; set; }
        [DataMember]
        public string ProcessorApprovalCode { get; set; }
        [DataMember]
        public string ProcessorReceiptCode { get; set; }
        [DataMember]
        public string ProcessorCCVResponse { get; set; }
        [DataMember]
        public string ProcessorReferenceNumber { get; set; }
        [DataMember]
        public string OrderID { get; set; }

        [DataMember]
        public string CommercialServiceProvider { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }

}
