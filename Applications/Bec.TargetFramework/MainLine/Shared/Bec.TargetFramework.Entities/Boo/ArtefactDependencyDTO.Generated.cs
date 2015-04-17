﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class ArtefactDependencyDTO
    {
        #region Constructors
  
        public ArtefactDependencyDTO() {
        }

        public ArtefactDependencyDTO(global::System.Guid artefactDependencyID, global::System.Guid artefactID, int artefactVersionNumber, global::System.Guid dependencyArtefactID, int dependencyArtefactVersionNumber, global::System.Guid artefactDependencyTemplateID, bool isActive, bool isDeleted, ArtefactDTO artefact_ArtefactID_ArtefactVersionNumber, ArtefactDependencyTemplateDTO artefactDependencyTemplate, ArtefactDTO artefact_DependencyArtefactID_DependencyArtefactVersionNumber) {

          this.ArtefactDependencyID = artefactDependencyID;
          this.ArtefactID = artefactID;
          this.ArtefactVersionNumber = artefactVersionNumber;
          this.DependencyArtefactID = dependencyArtefactID;
          this.DependencyArtefactVersionNumber = dependencyArtefactVersionNumber;
          this.ArtefactDependencyTemplateID = artefactDependencyTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Artefact_ArtefactID_ArtefactVersionNumber = artefact_ArtefactID_ArtefactVersionNumber;
          this.ArtefactDependencyTemplate = artefactDependencyTemplate;
          this.Artefact_DependencyArtefactID_DependencyArtefactVersionNumber = artefact_DependencyArtefactID_DependencyArtefactVersionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactDependencyID { get; set; }

        [DataMember]
        public global::System.Guid ArtefactID { get; set; }

        [DataMember]
        public int ArtefactVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid DependencyArtefactID { get; set; }

        [DataMember]
        public int DependencyArtefactVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ArtefactDependencyTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ArtefactDTO Artefact_ArtefactID_ArtefactVersionNumber { get; set; }

        [DataMember]
        public ArtefactDependencyTemplateDTO ArtefactDependencyTemplate { get; set; }

        [DataMember]
        public ArtefactDTO Artefact_DependencyArtefactID_DependencyArtefactVersionNumber { get; set; }

        #endregion
    }

}
