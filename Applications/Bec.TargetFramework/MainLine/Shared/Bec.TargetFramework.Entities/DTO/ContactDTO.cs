using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    public partial class ContactDTO
    {
        [DataMember]
        public string AddressesJson { get; set; }
        [DataMember]
        public List<string> AddressListItems { get; set; }
        [DataMember]
        public AddressDTO CurrentAddress { get; set; }
        [DataMember]
        public string SelectedAddress { get; set; }
        [DataMember]
        public string ContactJson { get; set; }

        [DataMember]
        public string FullName
        {
            get { return string.Format("{0} {1} {2}", Salutation, FirstName, LastName); }
        }

        #region Generic
        [DataMember]
        [Display(Name = "Is Head Office")]
        public bool IsHeadOffice { get; set; }
        [DataMember]
        [Display(Name = "Organisation Branch")]
        public string OrganisationBranchID { get; set; }

        [DataMember]
        public bool IsConcreteOrganisation { get; set; }
        [DataMember]
        public string OrganisationID { get; set; }

        #endregion
    }
}
