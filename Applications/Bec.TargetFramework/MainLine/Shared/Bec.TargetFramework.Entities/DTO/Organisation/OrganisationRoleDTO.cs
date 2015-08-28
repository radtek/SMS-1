using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
  
    public partial class OrganisationRoleDTO
    {
       
        [DataMember]
        public Guid RoleTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

   


        [DataMember]
        public Nullable<System.Guid> ModuleID { get; set; }

        [DataMember]
        public int? ModuleVersionNumber { get; set; }
    }
}
