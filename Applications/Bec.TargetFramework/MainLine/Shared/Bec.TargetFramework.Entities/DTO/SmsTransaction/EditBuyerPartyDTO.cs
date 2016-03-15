using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities
{
    [System.Serializable]
    public class EditBuyerPartyDTO
    {
        public Guid TxID { get; set; }
        public Guid UaoID { get; set; }
        public SmsUserAccountOrganisationTransactionDTO Dto { get; set; }
        public IEnumerable<FieldUpdateDTO> FieldUpdates { get; set; }
    }
}
