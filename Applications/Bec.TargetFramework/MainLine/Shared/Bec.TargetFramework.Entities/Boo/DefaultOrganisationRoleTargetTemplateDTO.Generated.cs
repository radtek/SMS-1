﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class DefaultOrganisationRoleTargetTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationRoleTargetTemplateDTO() {
        }

        public DefaultOrganisationRoleTargetTemplateDTO(global::System.Guid defaultOrganisationRoleTemplateID, bool isActive, bool isDeleted, global::System.Guid defaultOrganisationUserTargetTemplateID, DefaultOrganisationUserTargetTemplateDTO defaultOrganisationUserTargetTemplate, DefaultOrganisationRoleTemplateDTO defaultOrganisationRoleTemplate) {

          this.DefaultOrganisationRoleTemplateID = defaultOrganisationRoleTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationUserTargetTemplateID = defaultOrganisationUserTargetTemplateID;
          this.DefaultOrganisationUserTargetTemplate = defaultOrganisationUserTargetTemplate;
          this.DefaultOrganisationRoleTemplate = defaultOrganisationRoleTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationUserTargetTemplateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationUserTargetTemplateDTO DefaultOrganisationUserTargetTemplate { get; set; }

        [DataMember]
        public DefaultOrganisationRoleTemplateDTO DefaultOrganisationRoleTemplate { get; set; }

        #endregion
    }

}
