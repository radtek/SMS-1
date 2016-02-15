using System;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AssignSmsClientToTransactionDTO
    {
        public Guid TransactionID { get; set; }
        public Guid AssigningByOrganisationID { get; set; }
        public UserAccountOrganisationTransactionType UserAccountOrganisationTransactionType { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
