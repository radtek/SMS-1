using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodgeIt.TestDTOs
{
    public class SmsTransactionDTO
    {
        #region Constructors

        public SmsTransactionDTO()
        {
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SmsTransactionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> AddressID { get; set; }

        [DataMember]
        public global::System.Nullable<int> Price { get; set; }

        [DataMember]
        public string Reference { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> TenureTypeID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public long RowVersion { get; set; }

        [DataMember]
        public string MortgageApplicationNumber { get; set; }

        [DataMember]
        public string LenderName { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public AddressDTO Address { get; set; }

        #endregion
    }
}
