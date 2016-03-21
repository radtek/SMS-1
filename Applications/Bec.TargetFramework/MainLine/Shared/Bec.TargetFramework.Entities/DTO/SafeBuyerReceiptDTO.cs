using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    public class SafeBuyerReceiptDTO
    {
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string VatNumber { get; set; }
        [DataMember]
        public AddressDTO BecAddress { get; set; }
        [DataMember]
        public decimal Goods { get; set; }
        [DataMember]
        public decimal Vat { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public DateTime InvoiceDate { get; set; }
        [DataMember]
        public int InvoiceNumber { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public AddressDTO CustomerAddress { get; set; }
        [DataMember]
        public List<SafeBuyerReceiptItemDTO> Items { get; set; }
    }

    [Serializable]
    [DataContract]
    public class SafeBuyerReceiptItemDTO
    {
        [DataMember]
        public decimal Quantity { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal Goods { get; set; }
        [DataMember]
        public decimal Vat { get; set; }
        [DataMember]
        public decimal Total { get; set; }
    }
}
