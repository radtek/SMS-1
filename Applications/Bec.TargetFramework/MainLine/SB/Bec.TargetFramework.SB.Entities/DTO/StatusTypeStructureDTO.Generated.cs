﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 30/04/2015 14:40:27
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.SB.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class StatusTypeStructureDTO
    {
        #region Constructors
  
        public StatusTypeStructureDTO() {
        }

        public StatusTypeStructureDTO(global::System.Guid statusTypeStructureID, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Nullable<System.Guid> statusTypeValueID, int statusOrder, bool isStart, bool isEnd, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue, List<StatusTypeStructureTransitionDTO> statusTypeStructureTransitions_CurrentStatusTypeStructureID, List<StatusTypeStructureTransitionDTO> statusTypeStructureTransitions_NextStatusTypeStructureID) {

          this.StatusTypeStructureID = statusTypeStructureID;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.StatusOrder = statusOrder;
          this.IsStart = isStart;
          this.IsEnd = isEnd;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
          this.StatusTypeStructureTransitions_CurrentStatusTypeStructureID = statusTypeStructureTransitions_CurrentStatusTypeStructureID;
          this.StatusTypeStructureTransitions_NextStatusTypeStructureID = statusTypeStructureTransitions_NextStatusTypeStructureID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeStructureID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StatusTypeValueID { get; set; }

        [DataMember]
        public int StatusOrder { get; set; }

        [DataMember]
        public bool IsStart { get; set; }

        [DataMember]
        public bool IsEnd { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        [DataMember]
        public List<StatusTypeStructureTransitionDTO> StatusTypeStructureTransitions_CurrentStatusTypeStructureID { get; set; }

        [DataMember]
        public List<StatusTypeStructureTransitionDTO> StatusTypeStructureTransitions_NextStatusTypeStructureID { get; set; }

        #endregion
    }

}
