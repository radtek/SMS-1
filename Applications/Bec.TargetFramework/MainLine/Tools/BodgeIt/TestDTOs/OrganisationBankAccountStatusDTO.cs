using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodgeIt.TestDTOs
{
    public partial class OrganisationBankAccountStatusDTO
    {
        #region Constructors

        public OrganisationBankAccountStatusDTO()
        {
        }


        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationBankAccountID { get; set; }

        [DataMember]
        public string StatusChangedBy { get; set; }

        [DataMember]
        public global::System.DateTime StatusChangedOn { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public bool WasActive { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationBankAccountDTO OrganisationBankAccount { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        #endregion
    }
}