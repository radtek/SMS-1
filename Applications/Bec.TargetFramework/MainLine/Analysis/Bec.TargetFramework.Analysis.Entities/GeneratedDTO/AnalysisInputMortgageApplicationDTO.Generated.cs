﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 24/03/2015 09:58:29
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Analysis.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class AnalysisInputMortgageApplicationDTO
    {
        #region Constructors
  
        public AnalysisInputMortgageApplicationDTO() {
        }

        public AnalysisInputMortgageApplicationDTO(global::System.Guid analysisInputMortgageApplicationID, global::System.DateTime createdOn, string inputData, bool isActive, bool isDeleted, global::System.Guid analysisInputSchemaID, int analysisInputSchemaVersionNumber, string createdBy, global::System.Nullable<System.DateTime> modifiedOn, string modifiedBy, List<AnalysisInputMortgageApplicationDetailDTO> analysisInputMortgageApplicationDetails, AnalysisInputSchemaDTO analysisInputSchema, List<AnalysisProcessLogBatchDetailDTO> analysisProcessLogBatchDetails) {

          this.AnalysisInputMortgageApplicationID = analysisInputMortgageApplicationID;
          this.CreatedOn = createdOn;
          this.InputData = inputData;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.AnalysisInputSchemaID = analysisInputSchemaID;
          this.AnalysisInputSchemaVersionNumber = analysisInputSchemaVersionNumber;
          this.CreatedBy = createdBy;
          this.ModifiedOn = modifiedOn;
          this.ModifiedBy = modifiedBy;
          this.AnalysisInputMortgageApplicationDetails = analysisInputMortgageApplicationDetails;
          this.AnalysisInputSchema = analysisInputSchema;
          this.AnalysisProcessLogBatchDetails = analysisProcessLogBatchDetails;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AnalysisInputMortgageApplicationID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string InputData { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid AnalysisInputSchemaID { get; set; }

        [DataMember]
        public int AnalysisInputSchemaVersionNumber { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<AnalysisInputMortgageApplicationDetailDTO> AnalysisInputMortgageApplicationDetails { get; set; }

        [DataMember]
        public AnalysisInputSchemaDTO AnalysisInputSchema { get; set; }

        [DataMember]
        public List<AnalysisProcessLogBatchDetailDTO> AnalysisProcessLogBatchDetails { get; set; }

        #endregion
    }

}
