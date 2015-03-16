namespace Bec.TargetFramework.Entities.Enums
{
    /// <summary>
    /// Represents a payment method type
    /// </summary>
    public enum PaymentMethodEnum : int
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Card = 8500,
        /// <summary>
        /// All payment information is entered on the site
        /// </summary>
        Bacs = 8501,
        /// <summary>
        /// A customer is redirected to a third-party site in order to complete the payment
        /// </summary>
        DirectDebit = 8502,
    }
}
