﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class DefaultOrganisationGroupRoleTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationGroupRoleTemplateDTO() {
        }

        public DefaultOrganisationGroupRoleTemplateDTO(global::System.Guid defaultOrganisationGroupTemplateID, global::System.Guid defaultOrganisationRoleTemplateID, bool isActive, bool isDeleted, DefaultOrganisationGroupTemplateDTO defaultOrganisationGroupTemplate, DefaultOrganisationRoleTemplateDTO defaultOrganisationRoleTemplate) {

          this.DefaultOrganisationGroupTemplateID = defaultOrganisationGroupTemplateID;
          this.DefaultOrganisationRoleTemplateID = defaultOrganisationRoleTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationGroupTemplate = defaultOrganisationGroupTemplate;
          this.DefaultOrganisationRoleTemplate = defaultOrganisationRoleTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationGroupTemplateID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationGroupTemplateDTO DefaultOrganisationGroupTemplate { get; set; }

        [DataMember]
        public DefaultOrganisationRoleTemplateDTO DefaultOrganisationRoleTemplate { get; set; }

        #endregion
    }

}
