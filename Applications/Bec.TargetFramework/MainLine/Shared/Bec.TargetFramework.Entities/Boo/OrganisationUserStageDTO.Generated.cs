//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 6/27/2014 3:05:11 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class OrganisationUserStageDTO
    {
        #region Constructors
  
        public OrganisationUserStageDTO() {
        }

        public OrganisationUserStageDTO(global::System.Guid organisationUserStageID, string name, string description, int order, bool isActive, bool isDeleted, global::System.Guid organisationID, List<UserAccountOrganisationDTO> userAccountOrganisations) {

          this.OrganisationUserStageID = organisationUserStageID;
          this.Name = name;
          this.Description = description;
          this.Order = order;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationID = organisationID;
          this.UserAccountOrganisations = userAccountOrganisations;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationUserStageID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Order { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<UserAccountOrganisationDTO> UserAccountOrganisations { get; set; }

        #endregion
    }

}
