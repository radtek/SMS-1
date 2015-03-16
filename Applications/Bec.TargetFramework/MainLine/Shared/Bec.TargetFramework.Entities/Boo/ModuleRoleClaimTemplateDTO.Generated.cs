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
    public partial class ModuleRoleClaimTemplateDTO
    {
        #region Constructors
  
        public ModuleRoleClaimTemplateDTO() {
        }

        public ModuleRoleClaimTemplateDTO(global::System.Guid roleClaimID, global::System.Nullable<System.Guid> roleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, ModuleOperationTemplateDTO moduleOperationTemplate, ModuleResourceTemplateDTO moduleResourceTemplate, ModuleRoleTemplateDTO moduleRoleTemplate, ModuleStateItemTemplateDTO moduleStateItemTemplate, ModuleStateTemplateDTO moduleStateTemplate, ModuleTemplateDTO moduleTemplate) {

          this.RoleClaimID = roleClaimID;
          this.RoleID = roleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.ModuleOperationTemplate = moduleOperationTemplate;
          this.ModuleResourceTemplate = moduleResourceTemplate;
          this.ModuleRoleTemplate = moduleRoleTemplate;
          this.ModuleStateItemTemplate = moduleStateItemTemplate;
          this.ModuleStateTemplate = moduleStateTemplate;
          this.ModuleTemplate = moduleTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RoleClaimID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ResourceID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OperationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateItemID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleOperationTemplateDTO ModuleOperationTemplate { get; set; }

        [DataMember]
        public ModuleResourceTemplateDTO ModuleResourceTemplate { get; set; }

        [DataMember]
        public ModuleRoleTemplateDTO ModuleRoleTemplate { get; set; }

        [DataMember]
        public ModuleStateItemTemplateDTO ModuleStateItemTemplate { get; set; }

        [DataMember]
        public ModuleStateTemplateDTO ModuleStateTemplate { get; set; }

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        #endregion
    }

}
