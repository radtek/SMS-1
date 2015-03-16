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
    
    public  class OrganisationUserStateTemplateDTO
    {
        [DataMember]
        public System.Guid OrganisationUserStateTemplateId { get; set; }
        [DataMember]
        public System.Guid VisibilityStateTemplateId { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Organisation User State Template Name")]
        public string OrganisationUserStateTemplateName { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Organisation User State Template Description")]
        public string OrganisationUserStateTemplateDescription { get; set; }
        [DataMember]
        [Display(Name = "Is Primary State")]
        public Nullable<bool> IsPrimaryState { get; set; }
        [DataMember]
        public Nullable<int> OrganisationTypeId { get; set; }
        [DataMember]
        public Nullable<int> UserTypeId { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }
        [DataMember]
        public Nullable<bool> IsDisabled { get; set; }
        [DataMember]
        public Nullable<bool> IsDeleted { get; set; }

        
    
     
    }
}
