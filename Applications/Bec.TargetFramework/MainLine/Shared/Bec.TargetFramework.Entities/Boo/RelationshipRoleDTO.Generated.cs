﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class RelationshipRoleDTO
    {
        #region Constructors
  
        public RelationshipRoleDTO() {
        }

        public RelationshipRoleDTO(global::System.Guid relationshipRoleID, string name, string description, int relationshipRoleStatusID, int relationshipRoleStateID, bool isActive, bool isDeleted) {

          this.RelationshipRoleID = relationshipRoleID;
          this.Name = name;
          this.Description = description;
          this.RelationshipRoleStatusID = relationshipRoleStatusID;
          this.RelationshipRoleStateID = relationshipRoleStateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RelationshipRoleID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int RelationshipRoleStatusID { get; set; }

        [DataMember]
        public int RelationshipRoleStateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion
    }

}
