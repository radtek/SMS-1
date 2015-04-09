﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class ClassificationTypeCategoryDTO
    {
        #region Constructors
  
        public ClassificationTypeCategoryDTO() {
        }

        public ClassificationTypeCategoryDTO(int classificationTypeCategoryID, string name, bool isActive, bool isDeleted, List<ClassificationTypeDTO> classificationTypes_ClassificationTypeCategoryID, List<ClassificationTypeDTO> classificationTypes_ParentClassificationTypeCategoryID, List<UserAccountArchiveDTO> userAccountArchives) {

          this.ClassificationTypeCategoryID = classificationTypeCategoryID;
          this.Name = name;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ClassificationTypes_ClassificationTypeCategoryID = classificationTypes_ClassificationTypeCategoryID;
          this.ClassificationTypes_ParentClassificationTypeCategoryID = classificationTypes_ParentClassificationTypeCategoryID;
          this.UserAccountArchives = userAccountArchives;
        }

        #endregion

        #region Properties

        [DataMember]
        public int ClassificationTypeCategoryID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ClassificationTypeDTO> ClassificationTypes_ClassificationTypeCategoryID { get; set; }

        [DataMember]
        public List<ClassificationTypeDTO> ClassificationTypes_ParentClassificationTypeCategoryID { get; set; }

        [DataMember]
        public List<UserAccountArchiveDTO> UserAccountArchives { get; set; }

        #endregion
    }

}
