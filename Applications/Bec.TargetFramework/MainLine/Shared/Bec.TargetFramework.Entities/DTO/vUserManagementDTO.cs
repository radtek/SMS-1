using Bec.TargetFramework.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class vUserManagementDTO
    {
        public vUserManagementDTO()
        {
            AddressListItems = new List<ListItem>();
            UserContact = new ContactDTO();
        }

        [DataMember]
      
        public System.Guid UserDetailID { get; set; }

        [DataMember]
       
        public System.Guid UserID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Tenant { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataMember]
        [Display(Name="Middle Name")]
        public string MiddleName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataMember]
        [Display(Name="Mobile")]
        [RegularExpression(RegexExpressions.UKMobileExpression, ErrorMessage = "Please enter a valid UK Mobile Number")]
        public string HomeMobile { get; set; }

        [DataMember]
        [Display(Name = "Telephone")]
        [RegularExpression(RegexExpressions.UkTelephoneExpression, ErrorMessage = "Please enter a valid UK Telephone Number")]
        public string HomePhone { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Please Enter UserName"), StringLength(100)]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        [DataMember]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataMember]
        [Required(ErrorMessage = "Please Enter Email"), EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [DataMember]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [DataMember]
        public Nullable<System.DateTime> LastLogin { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsLoginAllowed { get; set; }

        [DataMember]
        public int? FailedLoginCount { get; set; }

        [DataMember]
        public string UnitName { get; set; }

        [DataMember]
        public string OrganisationName { get; set; }

        [DataMember]
        public string BranchName { get; set; }

        [DataMember]
        public string OrganisationDescription { get; set; }

        [DataMember]
        public Nullable<bool> IsBranch { get; set; }

        [DataMember]
        public string UserType { get; set; }

        [DataMember]
        public string UserCategoryType { get; set; }

        [DataMember]
         public Nullable<int> OrganisationUnitID { get; set; }

        [DataMember]
         [Required(ErrorMessage="Please Select Organisation")]
        public Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Please Select Branch")]
        public Nullable<System.Guid> BranchID { get; set; }

        [DataMember]
         [Required(ErrorMessage = "Please Select User Type")]
        public Nullable<int> UserTypeID { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Please Select User Category")]
        public Nullable<int> UserCategoryID { get; set; }

        [DataMember]
         public Nullable<System.Guid> OrganisationStructureID { get; set; }

        [DataMember]
        public Nullable<System.Guid> ParentOrganisationStructureID { get; set; }

        [DataMember]
        public Nullable<System.Guid> OrganisationUserStageID { get; set; }

        [DataMember]
        public Nullable<bool> IsLeafNode { get; set; }

        [DataMember]
        public List<ListItem> AddressListItems { get; set; }
        
        
        [DataMember]
        public ContactDTO UserContact { get; set; }
    }   
}
