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
    public partial class DefaultOrganisationGroupTargetTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationGroupTargetTemplateDTO() {
        }

        public DefaultOrganisationGroupTargetTemplateDTO(global::System.Guid defaultOrganisationGroupTemplateID, bool isActive, bool isDeleted, global::System.Guid defaultOrganisationUserTargetTemplateID, DefaultOrganisationUserTargetTemplateDTO defaultOrganisationUserTargetTemplate, DefaultOrganisationGroupTemplateDTO defaultOrganisationGroupTemplate) {

          this.DefaultOrganisationGroupTemplateID = defaultOrganisationGroupTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationUserTargetTemplateID = defaultOrganisationUserTargetTemplateID;
          this.DefaultOrganisationUserTargetTemplate = defaultOrganisationUserTargetTemplate;
          this.DefaultOrganisationGroupTemplate = defaultOrganisationGroupTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationGroupTemplateID { get; set; }

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
        public DefaultOrganisationGroupTemplateDTO DefaultOrganisationGroupTemplate { get; set; }

        #endregion
    }

}
