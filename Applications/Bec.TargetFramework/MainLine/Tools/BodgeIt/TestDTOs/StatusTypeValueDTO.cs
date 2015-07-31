using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodgeIt.TestDTOs
{
    public partial class StatusTypeValueDTO
    {
        #region Constructors

        public StatusTypeValueDTO()
        {
        }


        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties
        
        [DataMember]
        public List<OrganisationBankAccountStatusDTO> OrganisationBankAccountStatus { get; set; }

        #endregion
    }
}
