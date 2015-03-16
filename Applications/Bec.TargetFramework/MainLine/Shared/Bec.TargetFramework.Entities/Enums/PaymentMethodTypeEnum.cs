namespace Bec.TargetFramework.Entities.Enums
{
    /// <summary>
    /// Represents a payment method type
    /// </summary>
    public enum PaymentMethodTypeEnum : int
    {
        /// <summary>
        /// Unknown
        /// </summary>
        CreditCard = 8000,
        /// <summary>
        /// All payment information is entered on the site
        /// </summary>
        DebitCard = 8001,
    }
}
