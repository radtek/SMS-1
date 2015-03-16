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
    public class GroupTemplateDTO
    {
        [Required(ErrorMessage = "Please Enter an Group Template Name")]
        [DataType(DataType.Text)]
        [Display(Name = "Group Template Name")]
        //[Remote("CheckGroupTemplateName", "ReferenceData", "Admin")]
        [DataMember]
        public string GroupTemplateName { get; set; }

        [DataMember]
        public Guid GroupTemplateID { get; set; }

        [DataMember]
        public bool GroupTemplateSelected { get; set; }

        [DataMember]
        [Display(Name = "Group Template Description")]
        public string GroupTemplateDescription { get; set; }

        [Display(Name = "Type")]
        [DataMember]
        public int? GroupTypeID { get; set; }

        [Display(Name = "Category")]
        [DataMember]
        public int? RoleCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

    }
}
