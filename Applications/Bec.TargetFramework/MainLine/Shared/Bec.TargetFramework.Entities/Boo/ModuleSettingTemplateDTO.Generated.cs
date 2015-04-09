﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class ModuleSettingTemplateDTO
    {
        #region Constructors
  
        public ModuleSettingTemplateDTO() {
        }

        public ModuleSettingTemplateDTO(global::System.Guid moduleSettingTemplateID, string name, string value, bool isActive, bool isDeleted, bool canOrganisationChange, bool canUserChange, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, ModuleTemplateDTO moduleTemplate) {

          this.ModuleSettingTemplateID = moduleSettingTemplateID;
          this.Name = name;
          this.Value = value;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.CanOrganisationChange = canOrganisationChange;
          this.CanUserChange = canUserChange;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.ModuleTemplate = moduleTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleSettingTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool CanOrganisationChange { get; set; }

        [DataMember]
        public bool CanUserChange { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        #endregion
    }

}
