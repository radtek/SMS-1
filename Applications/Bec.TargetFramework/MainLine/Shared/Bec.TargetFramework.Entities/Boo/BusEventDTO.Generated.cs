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
    public partial class BusEventDTO
    {
        #region Constructors
  
        public BusEventDTO() {
        }

        public BusEventDTO(global::System.Guid busEventID, string busEventName, string busEventDescription, global::System.Guid busEventTypeID, BusEventTypeDTO busEventType, List<BusEventBusEventMessageSubscriberDTO> busEventBusEventMessageSubscribers) {

          this.BusEventID = busEventID;
          this.BusEventName = busEventName;
          this.BusEventDescription = busEventDescription;
          this.BusEventTypeID = busEventTypeID;
          this.BusEventType = busEventType;
          this.BusEventBusEventMessageSubscribers = busEventBusEventMessageSubscribers;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid BusEventID { get; set; }

        [DataMember]
        public string BusEventName { get; set; }

        [DataMember]
        public string BusEventDescription { get; set; }

        [DataMember]
        public global::System.Guid BusEventTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public BusEventTypeDTO BusEventType { get; set; }

        [DataMember]
        public List<BusEventBusEventMessageSubscriberDTO> BusEventBusEventMessageSubscribers { get; set; }

        #endregion
    }

}
