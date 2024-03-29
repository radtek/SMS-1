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
    public partial class OrganisationTypeUserTypeIdentityCheckTemplateDTO
    {
        #region Constructors
  
        public OrganisationTypeUserTypeIdentityCheckTemplateDTO() {
        }

        public OrganisationTypeUserTypeIdentityCheckTemplateDTO(int organisationTypeID, global::System.Guid identityCheckProviderID, int organisationTypeIdentityCheckTemplateID, int userTypeID, bool isDefault, bool isActive, bool isDeleted, IdentityCheckProviderDTO identityCheckProvider) {

          this.OrganisationTypeID = organisationTypeID;
          this.IdentityCheckProviderID = identityCheckProviderID;
          this.OrganisationTypeIdentityCheckTemplateID = organisationTypeIdentityCheckTemplateID;
          this.UserTypeID = userTypeID;
          this.IsDefault = isDefault;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IdentityCheckProvider = identityCheckProvider;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Guid IdentityCheckProviderID { get; set; }

        [DataMember]
        public int OrganisationTypeIdentityCheckTemplateID { get; set; }

        [DataMember]
        public int UserTypeID { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public IdentityCheckProviderDTO IdentityCheckProvider { get; set; }

        #endregion
    }

}
