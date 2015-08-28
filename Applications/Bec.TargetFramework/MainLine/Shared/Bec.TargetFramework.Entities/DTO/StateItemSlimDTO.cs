
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class StateItemSlimDTO
    {
        public StateItemSlimDTO()
        {
        }

        [DataMember]
       
        public Guid ParentStateID { get; set; }

        [DataMember]
       
        public string ParentStateItemName { get; set; }

        [DataMember]
       
        public Guid StateItemID { get; set; }

        [DataMember]
        public string ParentStateItemID { get; set; }

        [DataMember]
      
        public Guid StateID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [DataMember]

        public string StateItemName { get; set; }

    }

}