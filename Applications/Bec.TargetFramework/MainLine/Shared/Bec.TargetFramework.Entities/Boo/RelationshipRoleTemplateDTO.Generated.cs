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
    public partial class RelationshipRoleTemplateDTO
    {
        #region Constructors
  
        public RelationshipRoleTemplateDTO() {
        }

        public RelationshipRoleTemplateDTO(global::System.Guid relationshipRoleTemplateID, string name, string description, int relationshipRoleTemplateStatusID, int relationshipRoleTemplateStateID, bool isActive, bool isDeleted) {

          this.RelationshipRoleTemplateID = relationshipRoleTemplateID;
          this.Name = name;
          this.Description = description;
          this.RelationshipRoleTemplateStatusID = relationshipRoleTemplateStatusID;
          this.RelationshipRoleTemplateStateID = relationshipRoleTemplateStateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RelationshipRoleTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int RelationshipRoleTemplateStatusID { get; set; }

        [DataMember]
        public int RelationshipRoleTemplateStateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion
    }

}