using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
   
    public partial class OrganisationDetailDTO
    {
       // [Required(ErrorMessage = "Please Enter an Organisation Name")]
       // [DataType(DataType.Text)]
       // [Display(Name = "Name")]
       //// [Remote("DoesOrganisationNameExist", "Organisation",  "Component" )]
       // [DataMember]
       // public string Name { get; set; }

       // [DataMember]
       // public Guid OrganisationDetailID { get; set; }

       // [DataMember]
       // public Guid OrganisationID { get; set; }

        //[DataMember]
        //[Required]
        //[Display(Name = "Description")]
        //public string Description { get; set; }

        [Display(Name = "Type")]
        [Required]
        [DataMember]
        public int? OrganisationTypeID { get; set; }

        [Display(Name = "Template")]
        [Required]
        [DataMember]
        public Guid OrganisationTemplate { get; set; }

        [Display(Name = "Category")]
        [DataMember]
        public int? OrganisationCategoryID { get; set; }
    }
}
