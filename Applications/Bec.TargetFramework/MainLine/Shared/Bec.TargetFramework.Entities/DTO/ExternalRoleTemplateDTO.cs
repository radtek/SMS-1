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
    public class ExternalRoleTemplateDTO
    {
        [Required(ErrorMessage = "Please Enter an ExternalRole Template Name")]
        [DataType(DataType.Text)]
        [Display(Name = "ExternalRole Template Name")]
        //[Remote("CheckExternalRoleTemplateName", "ReferenceData", "Admin")]
        [DataMember]
        public string ExternalRoleTemplateName { get; set; }

        [DataMember]
        public Guid ExternalRoleTemplateID { get; set; }

        [DataMember]
        public bool ExternalRoleTemplateSelected { get; set; }

        [DataMember]
        [Display(Name = "ExternalRole Template Description")]
        public string ExternalRoleTemplateDescription { get; set; }
        
        [Display(Name = "Type")]
        [DataMember]
        public int? ExternalRoleTypeID { get; set; }

        [Display(Name = "Category")]
        [DataMember]
        public int? ExternalRoleCategoryID { get; set; }

    }
}
