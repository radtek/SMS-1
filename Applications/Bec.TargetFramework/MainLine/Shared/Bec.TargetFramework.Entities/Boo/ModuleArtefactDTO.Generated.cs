﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class ModuleArtefactDTO
    {
        #region Constructors
  
        public ModuleArtefactDTO() {
        }

        public ModuleArtefactDTO(global::System.Guid artefactID, int artefactVersionNumber, global::System.Guid moduleID, int moduleVersionNumber, bool isActive, bool isDeleted, ArtefactDTO artefact, ModuleDTO module) {

          this.ArtefactID = artefactID;
          this.ArtefactVersionNumber = artefactVersionNumber;
          this.ModuleID = moduleID;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Artefact = artefact;
          this.Module = module;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactID { get; set; }

        [DataMember]
        public int ArtefactVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ModuleID { get; set; }

        [DataMember]
        public int ModuleVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ArtefactDTO Artefact { get; set; }

        [DataMember]
        public ModuleDTO Module { get; set; }

        #endregion
    }

}
