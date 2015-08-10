using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodgeIt.TestDTOs
{
    public partial class OrganisationBankAccountDTO
    {
        #region Constructors

        public OrganisationBankAccountDTO()
        {
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationBankAccountID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public int BankAccountTypeID { get; set; }

        [DataMember]
        public string SortCode { get; set; }

        [DataMember]
        public string BankAccountNumber { get; set; }

        [DataMember]
        public string IBANNumber { get; set; }

        [DataMember]
        public string SwiftCode { get; set; }

        [DataMember]
        public int BankAccountDurationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> BankAccountOpeningYear { get; set; }

        [DataMember]
        public global::System.Nullable<int> BankAccountOpeningMonth { get; set; }

        [DataMember]
        public bool IsPrimary { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<long> RowVersion { get; set; }

        [DataMember]
        public global::System.DateTime Created { get; set; }

        [DataMember]
        public bool IsDirectDebtAccount { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<OrganisationBankAccountStatusDTO> OrganisationBankAccountStatus { get; set; }

        #endregion
    }
}
