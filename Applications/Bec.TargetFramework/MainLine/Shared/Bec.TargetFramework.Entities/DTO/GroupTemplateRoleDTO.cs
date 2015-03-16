using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public partial class GroupTemplateRoleDTO
    {

        //[Remote("CheckRoleClaimName", "ReferenceData", "Admin")]
        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleValue { get; set; }

    }
}
