﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class ContainsagadataDTO
    {
        #region Constructors
  
        public ContainsagadataDTO() {
        }

        public ContainsagadataDTO(global::System.Guid id, string originator, string originalmessageid) {

          this.Id = id;
          this.Originator = originator;
          this.Originalmessageid = originalmessageid;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid Id { get; set; }

        [DataMember]
        public string Originator { get; set; }

        [DataMember]
        public string Originalmessageid { get; set; }

        #endregion
    }

}
