using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class UserDetailDTO
    {
        public UserDetailDTO()
        {
            contact = new ContactDTO();
        }
        [Required(ErrorMessage = "Please Enter an User Name")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        // [Remote("DoesOrganisationNameExist", "Organisation",  "Component" )]
        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        public Guid UserID { get; set; }


        [DataMember]
        public Guid OrganisationID { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Email")]
        public string EmailAddress1 { get; set; }

        [Display(Name = "Organisation")]
        [Required]
        [DataMember]
        public string Organisation { get; set; }

        [Display(Name = "Type")]
        [Required]
        [DataMember]
        public int? OrganisationTypeID { get; set; }

        [Display(Name = "Category")]
        [DataMember]
        public int? OrganisationCategoryID { get; set; }

        [DataMember]
        public ContactDTO contact{ get; set; }
    }
}
