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
    public partial class DefaultOrganisationRoleRoleTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationRoleRoleTemplateDTO() {
        }

        public DefaultOrganisationRoleRoleTemplateDTO(global::System.Guid defaultOrganisationRoleID, global::System.Guid roleTemplateID, global::System.Guid moduleID, int moduleVersionNumber, DefaultOrganisationRoleDTO defaultOrganisationRole, ModuleDTO module) {

          this.DefaultOrganisationRoleID = defaultOrganisationRoleID;
          this.RoleTemplateID = roleTemplateID;
          this.ModuleID = moduleID;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.DefaultOrganisationRole = defaultOrganisationRole;
          this.Module = module;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleID { get; set; }

        [DataMember]
        public global::System.Guid RoleTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ModuleID { get; set; }

        [DataMember]
        public int ModuleVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationRoleDTO DefaultOrganisationRole { get; set; }

        [DataMember]
        public ModuleDTO Module { get; set; }

        #endregion
    }

}
