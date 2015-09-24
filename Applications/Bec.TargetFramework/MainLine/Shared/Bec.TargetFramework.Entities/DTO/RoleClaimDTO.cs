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
    public class RoleClaimDescriptionDTO
    {

        //[Remote("CheckRoleClaimName", "ReferenceData", "Admin")]
        [DataMember]
        public string RoleClaimName { get; set; }

        [DataMember]
        public string RoleClaimValue { get; set; }

    }
}
