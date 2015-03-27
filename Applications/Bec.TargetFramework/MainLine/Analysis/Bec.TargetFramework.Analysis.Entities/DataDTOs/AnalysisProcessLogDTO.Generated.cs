﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/5/2015 2:37:38 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Analysis
{

    [DataContractAttribute(IsReference=true)]
    public partial class AnalysisProcessLogDTO
    {
        #region Constructors
  
        public AnalysisProcessLogDTO() {
        }

        public AnalysisProcessLogDTO(global::System.Guid analysisProcessLogID, global::System.DateTime createdOn, global::System.Guid analysisInterfaceID, int analysisInterfaceVersionNumber, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, global::System.Nullable<bool> hasError, global::System.Nullable<bool> isComplete, global::System.Nullable<System.DateTime> completedOn, AnalysisInterfaceDTO analysisInterface, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue, List<AnalysisProcessLogStepDTO> analysisProcessLogSteps, List<AnalysisProcessLogStepOutputDTO> analysisProcessLogStepOutputs, List<AnalysisProcessLogBatchDTO> analysisProcessLogBatches, List<AnalysisProcessLogBatchDetailDTO> analysisProcessLogBatchDetails) {

          this.AnalysisProcessLogID = analysisProcessLogID;
          this.CreatedOn = createdOn;
          this.AnalysisInterfaceID = analysisInterfaceID;
          this.AnalysisInterfaceVersionNumber = analysisInterfaceVersionNumber;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.HasError = hasError;
          this.IsComplete = isComplete;
          this.CompletedOn = completedOn;
          this.AnalysisInterface = analysisInterface;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
          this.AnalysisProcessLogSteps = analysisProcessLogSteps;
          this.AnalysisProcessLogStepOutputs = analysisProcessLogStepOutputs;
          this.AnalysisProcessLogBatches = analysisProcessLogBatches;
          this.AnalysisProcessLogBatchDetails = analysisProcessLogBatchDetails;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AnalysisProcessLogID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Guid AnalysisInterfaceID { get; set; }

        [DataMember]
        public int AnalysisInterfaceVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> HasError { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsComplete { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CompletedOn { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public AnalysisInterfaceDTO AnalysisInterface { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        [DataMember]
        public List<AnalysisProcessLogStepDTO> AnalysisProcessLogSteps { get; set; }

        [DataMember]
        public List<AnalysisProcessLogStepOutputDTO> AnalysisProcessLogStepOutputs { get; set; }

        [DataMember]
        public List<AnalysisProcessLogBatchDTO> AnalysisProcessLogBatches { get; set; }

        [DataMember]
        public List<AnalysisProcessLogBatchDetailDTO> AnalysisProcessLogBatchDetails { get; set; }

        #endregion
    }

}
