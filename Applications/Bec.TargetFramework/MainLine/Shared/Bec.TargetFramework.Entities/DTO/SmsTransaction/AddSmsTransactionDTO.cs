using System;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AddSmsTransactionDTO
    {
        public SmsTransactionDTO SmsTransactionDTO { get; set; }
        public Guid? BuyerUaoId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string AdditionalAddressInformation { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
        public bool Manual { get; set; }
    }
}
