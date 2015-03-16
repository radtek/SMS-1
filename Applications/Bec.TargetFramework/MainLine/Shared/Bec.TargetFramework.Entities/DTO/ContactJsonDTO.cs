using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using Bec.TargetFramework.Entities.Helpers;
using System.Web.UI.WebControls;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class ContactJsonDTO
    {
        public ContactJsonDTO()
        {
            AddressListItems = new List<ListItem>();
            CurrentAddress = new AddressDTO();
            AddressesJson =new  List<AddressDTO>();
        }

        [DataMember]
        public System.Guid ContactID { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Name")]
        public string ContactName { get; set; }
        [DataMember]
        public Nullable<System.Guid> MasterContactID { get; set; }
        [DataMember]
        public System.Guid ParentID { get; set; }
        [DataMember]
        public Nullable<System.Guid> OwnerID { get; set; }
        [DataMember]
        [Display(Name = "Customer Type")]
        public string CustomerTypeID { get; set; }
        [DataMember]
        public Nullable<int> PreferredContactMethodID { get; set; }
        [DataMember]
        public Nullable<bool> IsBackOfficeCustomer { get; set; }
        [DataMember]
        [Display(Name = "Salutation")]
        public string Salutation { get; set; }
        [DataMember]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [DataMember]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [DataMember]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [DataMember]
        [Display(Name = "Nickname")]
        public string NickName { get; set; }
        [DataMember]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataMember]
        [Display(Name = "Birth Date")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [DataMember]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [DataMember]
        [Display(Name = "Gender")]
        public Nullable<int> GenderTypeID { get; set; }
        [DataMember]
        [Display(Name = "Has Children")]
        public Nullable<bool> HasChildren { get; set; }
        [DataMember]
        [Display(Name = "Education")]
        public Nullable<int> EducationTypeID { get; set; }
        [DataMember]
        [Display(Name = "Website")]
        public string WebSiteURL { get; set; }
        [DataMember]
        [Display(Name = "Email 1")]
        [RegularExpression(RegexExpressions.EmailExpression, ErrorMessage = "Please enter a valid Email Address")]
        [Required]
        public string EmailAddress1 { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.EmailExpression, ErrorMessage = "Please enter a valid Email Address")]
        [Display(Name = "Email 2")]
        public string EmailAddress2 { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.EmailExpression,ErrorMessage = "Please enter a valid Email Address")]
        [Display(Name = "Email 3")]
        public string EmailAddress3 { get; set; }
        [DataMember]
        public string AssistantName { get; set; }
        [DataMember]
        public string AssistantPhone { get; set; }
        [DataMember]
        public string ManagerName { get; set; }
        [DataMember]
        public string ManagerPhone { get; set; }
        [DataMember]
        public Nullable<int> CountryTypeID { get; set; }
        [DataMember]
        [Display(Name = "No fax")]
        public Nullable<bool> DoNotFax { get; set; }
        [DataMember]
        [Display(Name = "No Email")]
        public Nullable<bool> DoNotEmail { get; set; }
        [DataMember]
        [Display(Name = "No Telephone")]
        public Nullable<bool> DoNotTelephone { get; set; }
        [DataMember]
        public Nullable<bool> IsPrivate { get; set; }
        [DataMember]
        [Display(Name = "Telephone 1")]
        [Required]
        [RegularExpression(RegexExpressions.UkTelephoneExpression, ErrorMessage = "Please enter a valid UK Telephone Number")]
        public string Telephone1 { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.UkTelephoneExpression, ErrorMessage = "Please enter a valid UK Telephone Number")]
        [Display(Name = "Telephone 2")]
        public string Telephone2 { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.UkTelephoneExpression, ErrorMessage = "Please enter a valid UK Telephone Number")]
        [Display(Name = "Telephone 3")]
        public string Telephone3 { get; set; }
        [DataMember]
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.UKMobileExpression, ErrorMessage = "Please enter a valid UK Mobile Number")]
        [Display(Name = "Mobile 1")]
        public string MobileNumber1 { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.UKMobileExpression, ErrorMessage = "Please enter a valid UK Mobile Number")]
        [Display(Name = "Mobile 2")]
        public string MobileNumber2 { get; set; }
        [DataMember]
        [RegularExpression(RegexExpressions.UKMobileExpression, ErrorMessage = "Please enter a valid UK Mobile Number")]
        [Display(Name = "Mobile 3")]
        public string MobileNumber3 { get; set; }
        [DataMember]
        public Nullable<int> OrganisationUnitID { get; set; }
        [DataMember]
        public Nullable<System.Guid> ParentContactID { get; set; }
        [DataMember]
        public bool IsPrimaryContact { get; set; }
        [DataMember]
        [Display(Name = "Type")]
        [Required]
        public Nullable<int> ContactTypeID { get; set; }
        [DataMember]
        [Display(Name = "Category")]
        public Nullable<int> ContactCategoryID { get; set; }
        [DataMember]
        public List<AddressDTO> AddressesJson { get; set; }
        [DataMember]
        public List<ListItem> AddressListItems { get; set; }
        [DataMember]
        public AddressDTO CurrentAddress { get; set; }
        [DataMember]
        public string SelectedAddress { get; set; }
        [DataMember]
        public string ContactJson { get; set; }

        #region Generic
        [DataMember]
        public bool IsHeadOffice { get; set; }
        [DataMember]
        public Guid OrganisationBranchID { get; set; }

        #endregion
    }
}
