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
    public partial class FnSupportTicketRankResultDTO
    {
        #region Constructors
  
        public FnSupportTicketRankResultDTO() {
        }

        public FnSupportTicketRankResultDTO(global::System.Nullable<int> returnValue) {

          this.ReturnValue = returnValue;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Nullable<int> ReturnValue { get; set; }

        #endregion
    }

}