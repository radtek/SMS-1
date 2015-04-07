﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:18
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
    public partial class ArtefactDependencyTemplateDTO
    {
        #region Constructors
  
        public ArtefactDependencyTemplateDTO() {
        }

        public ArtefactDependencyTemplateDTO(global::System.Guid artefactDependencyTemplateID, global::System.Guid artefactTemplateID, int artefactTemplateVersionNumber, global::System.Guid dependencyArtefactTemplateID, int dependencyArtefactTemplateVersionNumber, bool isActive, bool isDeleted, ArtefactTemplateDTO artefactTemplate_ArtefactTemplateID_ArtefactTemplateVersionNumber, List<ArtefactDependencyDTO> artefactDependencies, ArtefactTemplateDTO artefactTemplate_DependencyArtefactTemplateID_DependencyArtefactTemplateVersionNumber) {

          this.ArtefactDependencyTemplateID = artefactDependencyTemplateID;
          this.ArtefactTemplateID = artefactTemplateID;
          this.ArtefactTemplateVersionNumber = artefactTemplateVersionNumber;
          this.DependencyArtefactTemplateID = dependencyArtefactTemplateID;
          this.DependencyArtefactTemplateVersionNumber = dependencyArtefactTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ArtefactTemplate_ArtefactTemplateID_ArtefactTemplateVersionNumber = artefactTemplate_ArtefactTemplateID_ArtefactTemplateVersionNumber;
          this.ArtefactDependencies = artefactDependencies;
          this.ArtefactTemplate_DependencyArtefactTemplateID_DependencyArtefactTemplateVersionNumber = artefactTemplate_DependencyArtefactTemplateID_DependencyArtefactTemplateVersionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactDependencyTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ArtefactTemplateID { get; set; }

        [DataMember]
        public int ArtefactTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid DependencyArtefactTemplateID { get; set; }

        [DataMember]
        public int DependencyArtefactTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ArtefactTemplateDTO ArtefactTemplate_ArtefactTemplateID_ArtefactTemplateVersionNumber { get; set; }

        [DataMember]
        public List<ArtefactDependencyDTO> ArtefactDependencies { get; set; }

        [DataMember]
        public ArtefactTemplateDTO ArtefactTemplate_DependencyArtefactTemplateID_DependencyArtefactTemplateVersionNumber { get; set; }

        #endregion
    }

}
