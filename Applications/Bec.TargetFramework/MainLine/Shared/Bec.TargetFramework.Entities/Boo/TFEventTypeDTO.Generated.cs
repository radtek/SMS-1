﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class TFEventTypeDTO
    {
        #region Constructors
  
        public TFEventTypeDTO() {
        }

        public TFEventTypeDTO(global::System.Guid tFEventTypeID, string name, List<TFEventDTO> tFEvents) {

          this.TFEventTypeID = tFEventTypeID;
          this.Name = name;
          this.TFEvents = tFEvents;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid TFEventTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<TFEventDTO> TFEvents { get; set; }

        #endregion
    }

}
