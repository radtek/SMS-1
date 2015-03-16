using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class AjaxRequestErrorDTO
    {
        [DataMember]
        public bool HasError { get; set; }
        [DataMember]
        public bool HasRedirectUrl { get; set; }
        [DataMember]
        public string RedirectUrl { get; set; }
    }
}
