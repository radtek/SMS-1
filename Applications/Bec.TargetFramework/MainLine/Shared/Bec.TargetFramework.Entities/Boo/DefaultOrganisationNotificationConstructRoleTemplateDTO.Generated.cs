//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 6/10/2014 2:36:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{

    [DataContractAttribute(IsReference=true)]
    public partial class DefaultOrganisationNotificationConstructRoleTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationNotificationConstructRoleTemplateDTO() {
        }

        public DefaultOrganisationNotificationConstructRoleTemplateDTO(global::System.Guid defaultOrganisationNotificationConstructTemplateID, global::System.Guid defaultOrganisationRoleID, bool isActive, bool isDeleted, DefaultOrganisationNotificationConstructTemplateDTO defaultOrganisationNotificationConstructTemplate, DefaultOrganisationRoleDTO defaultOrganisationRole) {

          this.DefaultOrganisationNotificationConstructTemplateID = defaultOrganisationNotificationConstructTemplateID;
          this.DefaultOrganisationRoleID = defaultOrganisationRoleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationNotificationConstructTemplate = defaultOrganisationNotificationConstructTemplate;
          this.DefaultOrganisationRole = defaultOrganisationRole;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationNotificationConstructTemplateID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationNotificationConstructTemplateDTO DefaultOrganisationNotificationConstructTemplate { get; set; }

        [DataMember]
        public DefaultOrganisationRoleDTO DefaultOrganisationRole { get; set; }

        #endregion
    }

}