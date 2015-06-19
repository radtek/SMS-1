using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
   
    /// <summary>
    /// Represents a payment info holder
    /// </summary>
    public partial class PaymentTransactionRequestDTO
    {
        [DataMember]
        public TransactionOrderDTO TransactionOrder { get; set; }

         [DataMember]
        public string PaymentTransactionType { get; set;} 

        [DataMember]

        public UserAccountDTO User { get; set; }

        public PaymentTransactionRequestDTO()
        {
            this.CustomValues = new Dictionary<string, object>();
        }
        [DataMember]
        /// <summary>
        /// Gets or sets a store identifier
        /// </summary>
        public int StoreId { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a customer identifier
        /// </summary>
        public int CustomerId { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets an order unique identifier. Used when order is not saved yet (payment gateways that do not redirect a customer to a third-party URL)
        /// </summary>
        public Guid OrderGuid { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets an order total
        /// </summary>
        public decimal OrderTotal { get; set; }
        [DataMember]
        /// <summary>
        /// /// <summary>
        /// Gets or sets a payment method identifier
        /// </summary>
        /// </summary>
        public string PaymentMethodSystemName { get; set; }

        #region Payment method specific properties
        [DataMember]
        /// <summary>
        /// Gets or sets a credit card type (Visa, Master Card, etc...)
        /// </summary>
        public string CreditCardType { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a credit card owner name
        /// </summary>
        public string CreditCardName { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a credit card number
        /// </summary>
        public string CreditCardNumber { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a credit card expire year
        /// </summary>
        public int CreditCardExpireYear { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a credit card expire month
        /// </summary>
        public int CreditCardExpireMonth { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a credit card CVV2 (Card Verification Value)
        /// </summary>
        public string CreditCardCvv2 { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a purchase order number (required for Purchase Order payment method)
        /// </summary>
        public string PurchaseOrderNumber { get; set; }

        #endregion Payment method specific properties

        #region Recurring payments
        [DataMember]
        /// <summary>
        /// Gets or sets a value idicating whether it's a recurring payment (initial payment was already processed)
        /// </summary>
        public bool IsRecurringPayment { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets an initial (parent) order identifier if order is recurring
        /// </summary>
        public int InitialOrderId { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the cycle length
        /// </summary>
        public int RecurringCycleLength { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the total cycles
        /// </summary>
        public int RecurringTotalCycles { get; set; }

        #endregion Recurring payments
        [DataMember]
        /// <summary>
        /// You can store any custom value in this property
        /// </summary>
        public Dictionary<string, object> CustomValues { get; set; }
    }
}