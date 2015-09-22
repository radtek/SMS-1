using System;
using System.ComponentModel.DataAnnotations;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AddSmsClientDTO
    {
        public Guid TransactionID { get; set; }
        public Guid OrganisationID { get; set; }
        public Guid UaoID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
    }
}
