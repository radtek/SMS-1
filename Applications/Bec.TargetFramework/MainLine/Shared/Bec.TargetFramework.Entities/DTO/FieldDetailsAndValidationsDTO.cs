using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class FieldDetailsAndValidationsDTO 
    {


        [DataMember]
        public List<VInterfacePanelValidationForUIDTO> InterfacePanelValidationsForUI { get; set; }

        [DataMember]
        public List<VFieldDetailValidationForUIDTO> FieldDetailValidationsForUI { get; set; }

        [DataMember]
        public List<VFieldDetailForUIDTO> FieldDetailsForUI { get; set; }

        [DataMember]
        public List<VInterfacePanelForUIDTO> InterfacePanelForUI { get; set; }
    }
}
