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
    public partial class VStateDTO
    {
        #region Constructors
  
        public VStateDTO() {
        }

        public VStateDTO(global::System.Guid stateID, global::System.Nullable<System.Guid> parentStateID, global::System.Guid stateItemID, global::System.Nullable<System.Guid> parentStateItemID, string stateName, string stateItemName, global::System.Nullable<int> stateItemOrder, string parentstateitemname) {

          this.StateID = stateID;
          this.ParentStateID = parentStateID;
          this.StateItemID = stateItemID;
          this.ParentStateItemID = parentStateItemID;
          this.StateName = stateName;
          this.StateItemName = stateItemName;
          this.StateItemOrder = stateItemOrder;
          this.Parentstateitemname = parentstateitemname;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentStateID { get; set; }

        [DataMember]
        public global::System.Guid StateItemID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentStateItemID { get; set; }

        [DataMember]
        public string StateName { get; set; }

        [DataMember]
        public string StateItemName { get; set; }

        [DataMember]
        public global::System.Nullable<int> StateItemOrder { get; set; }

        [DataMember]
        public string Parentstateitemname { get; set; }

        #endregion
    }

}
