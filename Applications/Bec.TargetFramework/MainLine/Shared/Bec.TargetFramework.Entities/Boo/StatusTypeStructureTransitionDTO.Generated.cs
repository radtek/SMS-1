﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class StatusTypeStructureTransitionDTO
    {
        #region Constructors
  
        public StatusTypeStructureTransitionDTO() {
        }

        public StatusTypeStructureTransitionDTO(global::System.Guid statusTypeStructureTransitionID, global::System.Guid currentStatusTypeStructureID, global::System.Guid nextStatusTypeStructureID, StatusTypeStructureDTO statusTypeStructure_NextStatusTypeStructureID, StatusTypeStructureDTO statusTypeStructure_CurrentStatusTypeStructureID) {

          this.StatusTypeStructureTransitionID = statusTypeStructureTransitionID;
          this.CurrentStatusTypeStructureID = currentStatusTypeStructureID;
          this.NextStatusTypeStructureID = nextStatusTypeStructureID;
          this.StatusTypeStructure_NextStatusTypeStructureID = statusTypeStructure_NextStatusTypeStructureID;
          this.StatusTypeStructure_CurrentStatusTypeStructureID = statusTypeStructure_CurrentStatusTypeStructureID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeStructureTransitionID { get; set; }

        [DataMember]
        public global::System.Guid CurrentStatusTypeStructureID { get; set; }

        [DataMember]
        public global::System.Guid NextStatusTypeStructureID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeStructureDTO StatusTypeStructure_NextStatusTypeStructureID { get; set; }

        [DataMember]
        public StatusTypeStructureDTO StatusTypeStructure_CurrentStatusTypeStructureID { get; set; }

        #endregion
    }

}
