﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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

        public TFEventMessageSubscriberDTO(global::System.Guid tFEventMessageSubscriberID, string name, string objectName, string objectAssembly, string defaultMessageSubscriberFilter, List<TFEventTFEventMessageSubscriberDTO> tFEventTFEventMessageSubscribers) {

          this.TFEventMessageSubscriberID = tFEventMessageSubscriberID;
          this.Name = name;
          this.ObjectName = objectName;
          this.ObjectAssembly = objectAssembly;
          this.DefaultMessageSubscriberFilter = defaultMessageSubscriberFilter;
          this.TFEventTFEventMessageSubscribers = tFEventTFEventMessageSubscribers;
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
        public List<TFEventTFEventMessageSubscriberDTO> TFEventTFEventMessageSubscribers { get; set; }

        #endregion
    }

}