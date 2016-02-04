using Bec.TargetFramework.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class RejectCompanyDTO
    {
        [DataMember]
        public Guid OrganisationId { get; set; }
        [DataMember]
        public int Reason { get; set; }
        [DataMember]
        public string Notes { get; set; }
        public string CompanyName { get; set; }
        public int ReturnTab { get; set; }
    }
}
