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
    public class ExternalRoleClaimDTO
    {

        //[Remote("CheckExternalRoleClaimName", "ReferenceData", "Admin")]
        [DataMember]
        public string ExternalRoleClaimName { get; set; }

        [DataMember]
        public string ExternalRoleClaimValue { get; set; }

    }
}
