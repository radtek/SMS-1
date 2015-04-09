using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    public class GeneratePinDTO
    {
        [DataMember]
        public Guid OrganisationId { get; set; }
        [DataMember]
        public string ContactedTelephoneNumber { get; set; }
    }
}
