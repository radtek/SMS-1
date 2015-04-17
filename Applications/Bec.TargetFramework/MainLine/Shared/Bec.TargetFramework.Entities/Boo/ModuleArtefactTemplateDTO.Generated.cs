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
    public partial class ModuleArtefactTemplateDTO
    {
        #region Constructors
  
        public ModuleArtefactTemplateDTO() {
        }

        public ModuleArtefactTemplateDTO(global::System.Guid artefactTemplateID, int artefactTemplateVersionNumber, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, bool isActive, bool isDeleted, ModuleTemplateDTO moduleTemplate, ArtefactTemplateDTO artefactTemplate) {

          this.ArtefactTemplateID = artefactTemplateID;
          this.ArtefactTemplateVersionNumber = artefactTemplateVersionNumber;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplate = moduleTemplate;
          this.ArtefactTemplate = artefactTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactTemplateID { get; set; }

        [DataMember]
        public int ArtefactTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        [DataMember]
        public ArtefactTemplateDTO ArtefactTemplate { get; set; }

        #endregion
    }

}
