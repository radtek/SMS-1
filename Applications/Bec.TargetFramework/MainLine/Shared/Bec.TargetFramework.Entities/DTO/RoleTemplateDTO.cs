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
    public class RoleTemplateDTO
    {
        [Required(ErrorMessage = "Please Enter an Role Template Name")]
        [DataType(DataType.Text)]
        [Display(Name = "Role Template Name")]
        //[Remote("CheckRoleTemplateName", "ReferenceData", "Admin")]
        [DataMember]
        public string RoleTemplateName { get; set; }

        [DataMember]
        public Guid RoleTemplateID { get; set; }

        [DataMember]
        public bool RoleTemplateSelected { get; set; }

        [DataMember]
        [Display(Name = "Role Template Description")]
        public string RoleTemplateDescription { get; set; }
        
        [Display(Name = "Type")]
        [DataMember]
        public int? RoleTypeID { get; set; }

        [Display(Name = "Category")]
        [DataMember]
        public int? RoleCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

    }
}
