﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class TFEventMessageSubscriberDTO
    {
        #region Constructors
  
        public TFEventMessageSubscriberDTO() {
        }

        public TFEventMessageSubscriberDTO(global::System.Guid tFEventMessageSubscriberID, string name, string objectName, string objectAssembly, string defaultMessageSubscriberFilter, List<TFEventDTO> tFEvents) {

          this.TFEventMessageSubscriberID = tFEventMessageSubscriberID;
          this.Name = name;
          this.ObjectName = objectName;
          this.ObjectAssembly = objectAssembly;
          this.DefaultMessageSubscriberFilter = defaultMessageSubscriberFilter;
          this.TFEvents = tFEvents;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid TFEventMessageSubscriberID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ObjectName { get; set; }

        [DataMember]
        public string ObjectAssembly { get; set; }

        [DataMember]
        public string DefaultMessageSubscriberFilter { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<TFEventDTO> TFEvents { get; set; }

        #endregion
    }

}
