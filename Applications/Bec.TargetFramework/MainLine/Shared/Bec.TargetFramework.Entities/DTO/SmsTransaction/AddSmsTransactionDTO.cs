using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AddSmsTransactionDTO
    {
        public SmsTransactionDTO SmsTransactionDTO { get; set; }
        public AddressDTO RegisteredHomeAddressDTO { get; set; }
        public IEnumerable<SmsSrcFundsBankAccountDTO> SmsSrcFundsBankAccounts { get; set; }
        public Guid? BuyerUaoID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool OrderProduct { get; set; }
    }
}
