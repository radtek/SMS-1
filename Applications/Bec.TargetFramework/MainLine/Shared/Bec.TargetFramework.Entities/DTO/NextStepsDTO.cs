using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
     public class NextStepsDTO {
    
        [DataMember]
        public string filename {get;set;}
        [DataMember]
        public bool  isCO {get;set;}
        [DataMember]
        public bool isExternalInvite {get;set;}
        [DataMember]
        public bool isRegistration {get;set;}
        [DataMember]
        public string nextStepsHtmlContent {get;set;}

    
    }
}
