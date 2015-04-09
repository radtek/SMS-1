﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:00:41
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Core.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class ClassificationTypeDTO
    {
        #region Constructors
  
        public ClassificationTypeDTO() {
        }

        public ClassificationTypeDTO(int classificationTypeID, string name, string description, int classificationTypeCategoryID, global::System.Nullable<int> parentClassificationTypeCategoryID, bool isActive, bool isDeleted, ClassificationTypeCategoryDTO classificationTypeCategory_ParentClassificationTypeCategoryID, ClassificationTypeCategoryDTO classificationTypeCategory_ClassificationTypeCategoryID) {

          this.ClassificationTypeID = classificationTypeID;
          this.Name = name;
          this.Description = description;
          this.ClassificationTypeCategoryID = classificationTypeCategoryID;
          this.ParentClassificationTypeCategoryID = parentClassificationTypeCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ClassificationTypeCategory_ParentClassificationTypeCategoryID = classificationTypeCategory_ParentClassificationTypeCategoryID;
          this.ClassificationTypeCategory_ClassificationTypeCategoryID = classificationTypeCategory_ClassificationTypeCategoryID;
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
        public ClassificationTypeCategoryDTO ClassificationTypeCategory_ParentClassificationTypeCategoryID { get; set; }

        [DataMember]
        public ClassificationTypeCategoryDTO ClassificationTypeCategory_ClassificationTypeCategoryID { get; set; }

        #endregion
    }

}
