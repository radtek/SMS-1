using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class vClassificationDTO
    {
        [DataMember]
        public int ClassificationTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
