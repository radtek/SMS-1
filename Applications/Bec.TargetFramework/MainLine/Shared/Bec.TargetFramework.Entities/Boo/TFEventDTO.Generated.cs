﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class TFEventDTO
    {
        #region Constructors
  
        public TFEventDTO() {
        }

        public TFEventDTO(global::System.Guid tFEventID, string tFEventName, string tFEventDescription, global::System.Guid tFEventTypeID, TFEventTypeDTO tFEventType, List<TFEventMessageSubscriberDTO> tFEventMessageSubscribers) {

          this.TFEventID = tFEventID;
          this.TFEventName = tFEventName;
          this.TFEventDescription = tFEventDescription;
          this.TFEventTypeID = tFEventTypeID;
          this.TFEventType = tFEventType;
          this.TFEventMessageSubscribers = tFEventMessageSubscribers;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid TFEventID { get; set; }

        [DataMember]
        public string TFEventName { get; set; }

        [DataMember]
        public string TFEventDescription { get; set; }

        [DataMember]
        public global::System.Guid TFEventTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public TFEventTypeDTO TFEventType { get; set; }

        [DataMember]
        public List<TFEventMessageSubscriberDTO> TFEventMessageSubscribers { get; set; }

        #endregion
    }

}
