﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:00:41
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Core.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class StatusTypeValueTemplateDTO
    {
        #region Constructors
  
        public StatusTypeValueTemplateDTO() {
        }

        public StatusTypeValueTemplateDTO(global::System.Guid statusTypeValueTemplateID, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, string name, string description, bool isActive, bool isDeleted, StatusTypeTemplateDTO statusTypeTemplate, List<StatusTypeStructureTemplateDTO> statusTypeStructureTemplates) {

          this.StatusTypeValueTemplateID = statusTypeValueTemplateID;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.StatusTypeTemplate = statusTypeTemplate;
          this.StatusTypeStructureTemplates = statusTypeStructureTemplates;
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
        public StatusTypeTemplateDTO StatusTypeTemplate { get; set; }

        [DataMember]
        public List<StatusTypeStructureTemplateDTO> StatusTypeStructureTemplates { get; set; }

        #endregion
    }

}
