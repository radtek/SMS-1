using System;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class ProductPurchaseResult
    {
        public Guid ShoppingCartTransactionOrderID { get; set; }
        public Guid InvoiceID { get; set; }
    }
}
