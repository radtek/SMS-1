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
    public partial class ModuleDependencyTemplateDTO
    {
        #region Constructors
  
        public ModuleDependencyTemplateDTO() {
        }

        public ModuleDependencyTemplateDTO(global::System.Guid moduleDependencyTemplateID, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, global::System.Guid dependencyID, int dependencyVersionNumber, bool isActive, bool isDeleted, ModuleTemplateDTO moduleTemplate) {

          this.ModuleDependencyTemplateID = moduleDependencyTemplateID;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.DependencyID = dependencyID;
          this.DependencyVersionNumber = dependencyVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplate = moduleTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleDependencyTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid DependencyID { get; set; }

        [DataMember]
        public int DependencyVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        #endregion
    }

}
