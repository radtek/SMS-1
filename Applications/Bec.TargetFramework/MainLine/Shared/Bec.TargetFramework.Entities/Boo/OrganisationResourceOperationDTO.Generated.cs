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
    public partial class OrganisationResourceOperationDTO
    {
        #region Constructors
  
        public OrganisationResourceOperationDTO() {
        }

        public OrganisationResourceOperationDTO(global::System.Guid resourceID, global::System.Guid operationID, bool isActive, bool isDeleted, global::System.Guid organisationID, global::System.Nullable<System.Guid> moduleID, global::System.Nullable<int> moduleVersionNumber, ModuleDTO module, OrganisationOperationDTO organisationOperation, OrganisationResourceDTO organisationResource) {

          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationID = organisationID;
          this.ModuleID = moduleID;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.Module = module;
          this.OrganisationOperation = organisationOperation;
          this.OrganisationResource = organisationResource;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ResourceID { get; set; }

        [DataMember]
        public global::System.Guid OperationID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ModuleID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ModuleVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleDTO Module { get; set; }

        [DataMember]
        public OrganisationOperationDTO OrganisationOperation { get; set; }

        [DataMember]
        public OrganisationResourceDTO OrganisationResource { get; set; }

        #endregion
    }

}