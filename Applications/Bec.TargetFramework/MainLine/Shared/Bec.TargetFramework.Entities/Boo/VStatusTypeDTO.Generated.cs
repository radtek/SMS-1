﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
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
    public partial class VStatusTypeDTO
    {
        #region Constructors
  
        public VStatusTypeDTO() {
        }

        public VStatusTypeDTO(global::System.Guid statusTypeValueID, global::System.Guid statusTypeID, int statusTypeVersionNumber, string name, string statusTypeName, int statusOrder, bool isStart, bool isEnd) {

          this.StatusTypeValueID = statusTypeValueID;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.Name = name;
          this.StatusTypeName = statusTypeName;
          this.StatusOrder = statusOrder;
          this.IsStart = isStart;
          this.IsEnd = isEnd;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string StatusTypeName { get; set; }

        [DataMember]
        public int StatusOrder { get; set; }

        [DataMember]
        public bool IsStart { get; set; }

        [DataMember]
        public bool IsEnd { get; set; }

        #endregion
    }

}
