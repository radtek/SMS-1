﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/06/2015 16:32:47
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.SB.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class BusEventMessageSubscriberDTO
    {
        #region Constructors
  
        public BusEventMessageSubscriberDTO() {
        }

        public BusEventMessageSubscriberDTO(global::System.Guid busEventMessageSubscriberID, string name, string objectName, string objectAssembly, string defaultMessageSubscriberFilter, List<BusEventBusEventMessageSubscriberDTO> busEventBusEventMessageSubscribers) {

          this.BusEventMessageSubscriberID = busEventMessageSubscriberID;
          this.Name = name;
          this.ObjectName = objectName;
          this.ObjectAssembly = objectAssembly;
          this.DefaultMessageSubscriberFilter = defaultMessageSubscriberFilter;
          this.BusEventBusEventMessageSubscribers = busEventBusEventMessageSubscribers;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid BusEventMessageSubscriberID { get; set; }

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
        public List<BusEventBusEventMessageSubscriberDTO> BusEventBusEventMessageSubscribers { get; set; }

        #endregion
    }

}