using System;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class AssignSmsClientToTransactionDTO
    {
        public Guid TransactionID { get; set; }
        public Guid UaoID { get; set; }
        public Guid AssigningByOrganisationID { get; set; }
        public UserAccountOrganisationTransactionType UserAccountOrganisationTransactionType { get; set; }
    }
}
