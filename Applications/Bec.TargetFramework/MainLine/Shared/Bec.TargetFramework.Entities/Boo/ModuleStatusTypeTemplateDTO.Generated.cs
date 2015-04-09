﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class ModuleStatusTypeTemplateDTO
    {
        #region Constructors
  
        public ModuleStatusTypeTemplateDTO() {
        }

        public ModuleStatusTypeTemplateDTO(global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, bool isActive, bool isDeleted, ModuleTemplateDTO moduleTemplate, StatusTypeTemplateDTO statusTypeTemplate) {

          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplate = moduleTemplate;
          this.StatusTypeTemplate = statusTypeTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        [DataMember]
        public StatusTypeTemplateDTO StatusTypeTemplate { get; set; }

        #endregion
    }

}
