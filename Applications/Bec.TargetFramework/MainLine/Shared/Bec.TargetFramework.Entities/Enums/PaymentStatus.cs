namespace Bec.TargetFramework.Entities.Enums
{
    /// <summary>
    /// Represents a payment status enumeration
    /// </summary>
    public enum PaymentStatus : int
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 10,

        /// <summary>
        /// Authorized
        /// </summary>
        Authorized = 20,

        /// <summary>
        /// Paid
        /// </summary>
        Paid = 30,

        /// <summary>
        /// Partially Refunded
        /// </summary>
        PartiallyRefunded = 35,

        /// <summary>
        /// Refunded
        /// </summary>
        Refunded = 40,

        /// <summary>
        /// Voided
        /// </summary>
        Voided = 50,
    }
}