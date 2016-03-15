using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    public class SmsTransactionPendingUpdateCountDTO
    {
        public Guid SmsTransactionID { get; set; }
        public int PendingChangesCount { get; set; }
    }
}
