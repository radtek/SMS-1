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
    public partial class VClassificationDTO
    {
        #region Constructors
  
        public VClassificationDTO() {
        }

        public VClassificationDTO(int classificationtypeid, string name, int classificationTypeCategoryID, string categoryname) {

          this.Classificationtypeid = classificationtypeid;
          this.Name = name;
          this.ClassificationTypeCategoryID = classificationTypeCategoryID;
          this.Categoryname = categoryname;
        }

        #endregion

        #region Properties

        [DataMember]
        public int Classificationtypeid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int ClassificationTypeCategoryID { get; set; }

        [DataMember]
        public string Categoryname { get; set; }

        #endregion
    }

}
