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
    public partial class StatusTypeTemplateDTO
    {
        #region Constructors
  
        public StatusTypeTemplateDTO() {
        }

        public StatusTypeTemplateDTO(global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, string name, string description, bool isActive, bool isDeleted, List<StatusTypeDTO> statusTypes, List<ModuleStatusTypeTemplateDTO> moduleStatusTypeTemplates, List<StatusTypeRoleTemplateDTO> statusTypeRoleTemplates, List<WorkflowStatusTypeTemplateDTO> workflowStatusTypeTemplates, List<DefaultOrganisationStatusTypeTemplateDTO> defaultOrganisationStatusTypeTemplates, List<StatusTypeStructureTemplateDTO> statusTypeStructureTemplates, List<StatusTypeClaimTemplateDTO> statusTypeClaimTemplates, List<StatusTypeValueTemplateDTO> statusTypeValueTemplates, List<ArtefactTemplateDTO> artefactTemplates) {

          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.StatusTypes = statusTypes;
          this.ModuleStatusTypeTemplates = moduleStatusTypeTemplates;
          this.StatusTypeRoleTemplates = statusTypeRoleTemplates;
          this.WorkflowStatusTypeTemplates = workflowStatusTypeTemplates;
          this.DefaultOrganisationStatusTypeTemplates = defaultOrganisationStatusTypeTemplates;
          this.StatusTypeStructureTemplates = statusTypeStructureTemplates;
          this.StatusTypeClaimTemplates = statusTypeClaimTemplates;
          this.StatusTypeValueTemplates = statusTypeValueTemplates;
          this.ArtefactTemplates = artefactTemplates;
        }

        #endregion

        #region Properties

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
        public List<StatusTypeDTO> StatusTypes { get; set; }

        [DataMember]
        public List<ModuleStatusTypeTemplateDTO> ModuleStatusTypeTemplates { get; set; }

        [DataMember]
        public List<StatusTypeRoleTemplateDTO> StatusTypeRoleTemplates { get; set; }

        [DataMember]
        public List<WorkflowStatusTypeTemplateDTO> WorkflowStatusTypeTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationStatusTypeTemplateDTO> DefaultOrganisationStatusTypeTemplates { get; set; }

        [DataMember]
        public List<StatusTypeStructureTemplateDTO> StatusTypeStructureTemplates { get; set; }

        [DataMember]
        public List<StatusTypeClaimTemplateDTO> StatusTypeClaimTemplates { get; set; }

        [DataMember]
        public List<StatusTypeValueTemplateDTO> StatusTypeValueTemplates { get; set; }

        [DataMember]
        public List<ArtefactTemplateDTO> ArtefactTemplates { get; set; }

        #endregion
    }

}
