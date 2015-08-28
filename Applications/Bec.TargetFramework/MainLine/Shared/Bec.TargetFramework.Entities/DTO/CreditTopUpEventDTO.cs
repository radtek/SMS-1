using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class CreditTopUpEventDTO
    {
        public Guid TransactionOrderID { get; set; }
        public decimal Amount { get; set; }
    }
}
