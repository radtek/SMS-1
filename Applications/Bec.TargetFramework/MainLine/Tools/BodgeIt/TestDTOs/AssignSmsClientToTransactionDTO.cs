using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodgeIt.TestDTOs
{

    [System.Serializable]
    public class AssignSmsClientToTransactionDTO
    {
        public Guid TransactionID { get; set; }
        public Guid UaoID { get; set; }
        public Guid AssigningByOrganisationID { get; set; }
        public UserAccountOrganisationTransactionType UserAccountOrganisationTransactionType { get; set; }
    }

    public enum UserAccountOrganisationTransactionType
    {
        Buyer = 1,
        AdditionalBuyer = 2,
        Giftor = 3,
        Seller = 4
    }
}
