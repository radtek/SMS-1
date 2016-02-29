using Bec.TargetFramework.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AddSmsClientDTO
    {
        public Guid TransactionID { get; set; }
        public Guid OrganisationID { get; set; }
        public Guid UaoID { get; set; }
        public UserAccountOrganisationTransactionType UserAccountOrganisationTransactionType { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
        public AddressDTO RegisteredHomeAddressDTO { get; set; }
        public IEnumerable<SmsSrcFundsBankAccountDTO> SmsSrcFundsBankAccounts { get; set; }
    }
}
