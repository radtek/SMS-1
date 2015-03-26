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
    public partial class AnalysisBatchSenderDTO
    {
        #region Constructors
  
        public AnalysisBatchSenderDTO() {
        }

        public AnalysisBatchSenderDTO(global::System.Guid analysisBatchSenderID, int analysisBatchSenderVersionNumber, string name, string description, bool isActive, bool isDeleted, global::System.Nullable<int> analysisBatchSenderTypeID, global::System.Nullable<int> analysisBatchSenderCategoryID, string objectName, string objectAssembly, List<AnalysisInterfaceDTO> analysisInterfaces) {

          this.AnalysisBatchSenderID = analysisBatchSenderID;
          this.AnalysisBatchSenderVersionNumber = analysisBatchSenderVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.AnalysisBatchSenderTypeID = analysisBatchSenderTypeID;
          this.AnalysisBatchSenderCategoryID = analysisBatchSenderCategoryID;
          this.ObjectName = objectName;
          this.ObjectAssembly = objectAssembly;
          this.AnalysisInterfaces = analysisInterfaces;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AnalysisBatchSenderID { get; set; }

        [DataMember]
        public int AnalysisBatchSenderVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> AnalysisBatchSenderTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AnalysisBatchSenderCategoryID { get; set; }

        [DataMember]
        public string ObjectName { get; set; }

        [DataMember]
        public string ObjectAssembly { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<AnalysisInterfaceDTO> AnalysisInterfaces { get; set; }

        #endregion
    }

}
