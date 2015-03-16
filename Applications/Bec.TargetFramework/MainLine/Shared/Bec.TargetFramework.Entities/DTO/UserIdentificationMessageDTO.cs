using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.DTO
{
    [DataContract]
    public class UserIdentificationMessageDTO
    {
        [DataMember]
        public Guid UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}
