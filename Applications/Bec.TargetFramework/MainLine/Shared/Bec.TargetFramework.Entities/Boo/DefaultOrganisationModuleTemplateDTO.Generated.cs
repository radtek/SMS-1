﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class DefaultOrganisationModuleTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationModuleTemplateDTO() {
        }

        public DefaultOrganisationModuleTemplateDTO(global::System.Guid defaultOrganisationTemplateID, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, global::System.Nullable<System.Guid> parentID, bool isActive, bool isDeleted, int defaultOrganisationTemplateVersionNumber, DefaultOrganisationTemplateDTO defaultOrganisationTemplate, ModuleTemplateDTO moduleTemplate) {

          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.ParentID = parentID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.DefaultOrganisationTemplate = defaultOrganisationTemplate;
          this.ModuleTemplate = moduleTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int DefaultOrganisationTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationTemplateDTO DefaultOrganisationTemplate { get; set; }

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        #endregion
    }

}
