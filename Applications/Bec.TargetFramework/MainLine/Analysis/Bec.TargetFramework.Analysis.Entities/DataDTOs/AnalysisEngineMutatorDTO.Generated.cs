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
    public partial class AnalysisEngineMutatorDTO
    {
        #region Constructors
  
        public AnalysisEngineMutatorDTO() {
        }

        public AnalysisEngineMutatorDTO(global::System.Guid analysisEngineID, int analysisEngineVersionNumber, global::System.Guid analysisMutatorID, int analysisMutatorVersionNumber, int order) {

          this.AnalysisEngineID = analysisEngineID;
          this.AnalysisEngineVersionNumber = analysisEngineVersionNumber;
          this.AnalysisMutatorID = analysisMutatorID;
          this.AnalysisMutatorVersionNumber = analysisMutatorVersionNumber;
          this.Order = order;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AnalysisEngineID { get; set; }

        [DataMember]
        public int AnalysisEngineVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid AnalysisMutatorID { get; set; }

        [DataMember]
        public int AnalysisMutatorVersionNumber { get; set; }

        [DataMember]
        public int Order { get; set; }

        #endregion
    }

}
