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
    public  class OrganisationUserStateDTO
    {
        [DataMember]
        public System.Guid OrganisationUserStateId { get; set; }
        [DataMember]
        public System.Guid OrganisationVisibilityStateId { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Organisation User State Name")]
        public string OrganisationUserStateName { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Organisation User State Description")]
        public string OrganisationUserStateDescription { get; set; }
        [DataMember]
        public Nullable<bool> IsPrimaryState { get; set; }
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
