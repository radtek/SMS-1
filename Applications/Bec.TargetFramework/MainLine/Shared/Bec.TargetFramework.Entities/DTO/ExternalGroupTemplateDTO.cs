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
    public class ExternalGroupTemplateDTO
    {
        [Required(ErrorMessage = "Please Enter an ExternalGroup Template Name")]
        [DataType(DataType.Text)]
        [Display(Name = "ExternalGroup Template Name")]
        //[Remote("CheckExternalGroupTemplateName", "ReferenceData", "Admin")]
        [DataMember]
        public string ExternalGroupTemplateName { get; set; }

        [DataMember]
        public Guid ExternalGroupTemplateID { get; set; }

        [DataMember]
        public bool ExternalGroupTemplateSelected { get; set; }

        [DataMember]
        [Display(Name = "ExternalGroup Template Description")]
        public string ExternalGroupTemplateDescription { get; set; }

        [Display(Name = "Type")]
        [DataMember]
        public int ExternalGroupTypeID { get; set; }

        [Display(Name = "Category")]
        [DataMember]
        public int? RoleCategoryID { get; set; }

    }
}
