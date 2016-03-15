using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class EditSmsTransactionDTO
    {
        public Guid TxID { get; set; }
        public Guid OrgID { get; set; }
        public SmsTransactionDTO Dto { get; set; }
        public IEnumerable<FieldUpdateDTO> FieldUpdates { get; set; }
    }
}
