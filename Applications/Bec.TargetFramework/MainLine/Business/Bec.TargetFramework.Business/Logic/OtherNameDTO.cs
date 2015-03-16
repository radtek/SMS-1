using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Serializable]
    [DataContract]
    public class PersonalDetailDTO
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public int TitleTypeID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}
