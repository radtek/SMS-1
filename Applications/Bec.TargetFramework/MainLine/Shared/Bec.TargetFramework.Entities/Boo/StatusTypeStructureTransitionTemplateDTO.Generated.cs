﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class StatusTypeStructureTransitionTemplateDTO
    {
        #region Constructors
  
        public StatusTypeStructureTransitionTemplateDTO() {
        }

        public StatusTypeStructureTransitionTemplateDTO(global::System.Guid statusTypeStructureTransitionTemplateID, global::System.Guid currentStatusTypeStructureTemplateID, global::System.Guid nextStatusTypeStructureTemplateID, StatusTypeStructureTemplateDTO statusTypeStructureTemplate_NextStatusTypeStructureTemplateID, StatusTypeStructureTemplateDTO statusTypeStructureTemplate_CurrentStatusTypeStructureTemplateID) {

          this.StatusTypeStructureTransitionTemplateID = statusTypeStructureTransitionTemplateID;
          this.CurrentStatusTypeStructureTemplateID = currentStatusTypeStructureTemplateID;
          this.NextStatusTypeStructureTemplateID = nextStatusTypeStructureTemplateID;
          this.StatusTypeStructureTemplate_NextStatusTypeStructureTemplateID = statusTypeStructureTemplate_NextStatusTypeStructureTemplateID;
          this.StatusTypeStructureTemplate_CurrentStatusTypeStructureTemplateID = statusTypeStructureTemplate_CurrentStatusTypeStructureTemplateID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeStructureTransitionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid CurrentStatusTypeStructureTemplateID { get; set; }

        [DataMember]
        public global::System.Guid NextStatusTypeStructureTemplateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeStructureTemplateDTO StatusTypeStructureTemplate_NextStatusTypeStructureTemplateID { get; set; }

        [DataMember]
        public StatusTypeStructureTemplateDTO StatusTypeStructureTemplate_CurrentStatusTypeStructureTemplateID { get; set; }

        #endregion
    }

}
