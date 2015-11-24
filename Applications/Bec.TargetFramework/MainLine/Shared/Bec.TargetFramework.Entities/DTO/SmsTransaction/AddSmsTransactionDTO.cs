using System;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AddSmsTransactionDTO
    {
        public SmsTransactionDTO SmsTransactionDTO { get; set; }
        public Guid? BuyerUaoID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
