﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class DirectDebitScheduleDTO
    {
        #region Constructors
  
        public DirectDebitScheduleDTO() {
        }

        public DirectDebitScheduleDTO(global::System.Guid directDebitScheduleID) {

          this.DirectDebitScheduleID = directDebitScheduleID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DirectDebitScheduleID { get; set; }

        #endregion
    }

}
