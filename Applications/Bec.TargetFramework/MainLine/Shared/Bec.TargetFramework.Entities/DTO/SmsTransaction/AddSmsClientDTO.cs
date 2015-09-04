using System;
using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AddSmsClientDTO
    {
        public Guid TransactionId { get; set; }
        public Guid OrganisationId { get; set; }
        public Guid UaoId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
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
