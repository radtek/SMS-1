﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class StatusTypeValueTemplateDTO
    {
        #region Constructors
  
        public StatusTypeValueTemplateDTO() {
        }

        public StatusTypeValueTemplateDTO(global::System.Guid statusTypeValueTemplateID, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, string name, string description, bool isActive, bool isDeleted, List<DefaultOrganisationStatusTypeTemplateDTO> defaultOrganisationStatusTypeTemplates, List<StatusTypeStructureTemplateDTO> statusTypeStructureTemplates, StatusTypeTemplateDTO statusTypeTemplate) {

          this.StatusTypeValueTemplateID = statusTypeValueTemplateID;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationStatusTypeTemplates = defaultOrganisationStatusTypeTemplates;
          this.StatusTypeStructureTemplates = statusTypeStructureTemplates;
          this.StatusTypeTemplate = statusTypeTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeValueTemplateID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationStatusTypeTemplateDTO> DefaultOrganisationStatusTypeTemplates { get; set; }

        [DataMember]
        public List<StatusTypeStructureTemplateDTO> StatusTypeStructureTemplates { get; set; }

        [DataMember]
        public StatusTypeTemplateDTO StatusTypeTemplate { get; set; }

        #endregion
    }

}
