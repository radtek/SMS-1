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
    public partial class VStatusTypeTemplateDTO
    {
        #region Constructors
  
        public VStatusTypeTemplateDTO() {
        }

        public VStatusTypeTemplateDTO(global::System.Guid statusTypeValueTemplateID, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, string name, string templateName, int statusOrder, bool isStart, bool isEnd) {

          this.StatusTypeValueTemplateID = statusTypeValueTemplateID;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.Name = name;
          this.TemplateName = templateName;
          this.StatusOrder = statusOrder;
          this.IsStart = isStart;
          this.IsEnd = isEnd;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeValueTemplateID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string TemplateName { get; set; }

        [DataMember]
        public int StatusOrder { get; set; }

        [DataMember]
        public bool IsStart { get; set; }

        [DataMember]
        public bool IsEnd { get; set; }

        #endregion
    }

}
