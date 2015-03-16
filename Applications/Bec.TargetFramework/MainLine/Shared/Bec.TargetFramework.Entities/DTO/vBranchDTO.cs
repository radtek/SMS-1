using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Entities.Helpers;
using ServiceStack.Text;
using System.Web.UI.WebControls;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class vBranchDTO
    {
        public vBranchDTO()
        {
            Addresses = new List<AddressDTO>();
            AddressListItems = new List<ListItem>();
            CurrentAddress = new AddressDTO();
            AddressesJson = JsonSerializer.SerializeToString(new List<AddressDTO>());
        }

        [DataMember]
        public System.Guid ParentOrganisationID { get; set; }

        [DataMember]
        public System.Guid BranchOrganisationID { get; set; }

        [DataMember]
        public bool IsHeadOffice { get; set; }

        [DataMember]
        public System.Guid ContactID { get; set; }

        [DataMember]
        [Display(Name = "Name")]
        public string BranchName { get; set; }

        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        [RegularExpression(RegexExpressions.EmailExpression, ErrorMessage = "Please enter a valid Email Address")]
        public string EmailAddress1 { get; set; }

        [DataMember]
        [RegularExpression(RegexExpressions.UkTelephoneExpression, ErrorMessage = "Please enter a valid UK Telephone Number")]
        public string Telephone1 { get; set; }

        public List<AddressDTO> Addresses { get; set; }

        [DataMember]
        public bool IsPrimaryContact { get; set; }

        [DataMember]
        [RegularExpression(RegexExpressions.UkTelephoneExpression, ErrorMessage = "Please enter a valid UK Telephone Number")]
        public string Telephone2 { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.UKMobileExpression, ErrorMessage = "Please enter a valid UK Mobile Number")]
        public string MobileNumber1 { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.UKMobileExpression, ErrorMessage = "Please enter a valid UK Mobile Number")]
        public string MobileNumber2 { get; set; }
        [DataMember]
        public string EmailAddress2 { get; set; }
        [DataMember]
        public string WebSiteURL { get; set; }
        [DataMember]
        public Nullable<int> ContactCategoryID { get; set; }
        [DataMember]
        public Nullable<int> ContactTypeID { get; set; }

        [DataMember]
        public string AddressesJson { get; set; }
        [DataMember]
        public List<ListItem> AddressListItems { get; set; }
        [DataMember]
        public AddressDTO CurrentAddress { get; set; }
        [DataMember]
        public string SelectedAddress { get; set; }

    }
}
