using System;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class ProductPurchaseResult
    {
        public Guid ShoppingCartTransactionOrderId { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
