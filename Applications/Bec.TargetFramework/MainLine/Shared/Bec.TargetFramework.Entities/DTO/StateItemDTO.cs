
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    public partial class StateItemDTO
    {


        [DataMember]
        public List<StateItemDTO> Children { get; set; }


        [DataMember]
        public string ParentStateItemName { get; set; }
    }
}