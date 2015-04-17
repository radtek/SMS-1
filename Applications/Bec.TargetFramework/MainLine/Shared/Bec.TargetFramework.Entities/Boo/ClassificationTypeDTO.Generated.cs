﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class ClassificationTypeDTO
    {
        #region Constructors
  
        public ClassificationTypeDTO() {
        }

        public ClassificationTypeDTO(int classificationTypeID, string name, string description, int classificationTypeCategoryID, global::System.Nullable<int> parentClassificationTypeCategoryID, bool isActive, bool isDeleted, List<PasswordResetSecretDTO> passwordResetSecrets, ClassificationTypeCategoryDTO classificationTypeCategory_ClassificationTypeCategoryID, ClassificationTypeCategoryDTO classificationTypeCategory_ParentClassificationTypeCategoryID, List<UserAccountArchiveDTO> userAccountArchives) {

          this.ClassificationTypeID = classificationTypeID;
          this.Name = name;
          this.Description = description;
          this.ClassificationTypeCategoryID = classificationTypeCategoryID;
          this.ParentClassificationTypeCategoryID = parentClassificationTypeCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PasswordResetSecrets = passwordResetSecrets;
          this.ClassificationTypeCategory_ClassificationTypeCategoryID = classificationTypeCategory_ClassificationTypeCategoryID;
          this.ClassificationTypeCategory_ParentClassificationTypeCategoryID = classificationTypeCategory_ParentClassificationTypeCategoryID;
          this.UserAccountArchives = userAccountArchives;
        }

        #endregion

        #region Properties

        [DataMember]
        public int ClassificationTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int ClassificationTypeCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ParentClassificationTypeCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<PasswordResetSecretDTO> PasswordResetSecrets { get; set; }

        [DataMember]
        public ClassificationTypeCategoryDTO ClassificationTypeCategory_ClassificationTypeCategoryID { get; set; }

        [DataMember]
        public ClassificationTypeCategoryDTO ClassificationTypeCategory_ParentClassificationTypeCategoryID { get; set; }

        [DataMember]
        public List<UserAccountArchiveDTO> UserAccountArchives { get; set; }

        #endregion
    }

}
