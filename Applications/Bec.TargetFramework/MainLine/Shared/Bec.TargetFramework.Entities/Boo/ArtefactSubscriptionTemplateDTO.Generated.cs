﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class ArtefactSubscriptionTemplateDTO
    {
        #region Constructors
  
        public ArtefactSubscriptionTemplateDTO() {
        }

        public ArtefactSubscriptionTemplateDTO(global::System.Guid artefactSubscriptionTemplateID, global::System.Guid artefactTemplateID, int artefactTemplateVersionNumber, bool isActive, bool isDeleted, global::System.Guid planSubscriptionTemplateID, int planSubscriptionTemplateVersionNumber, ArtefactTemplateDTO artefactTemplate) {

          this.ArtefactSubscriptionTemplateID = artefactSubscriptionTemplateID;
          this.ArtefactTemplateID = artefactTemplateID;
          this.ArtefactTemplateVersionNumber = artefactTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PlanSubscriptionTemplateID = planSubscriptionTemplateID;
          this.PlanSubscriptionTemplateVersionNumber = planSubscriptionTemplateVersionNumber;
          this.ArtefactTemplate = artefactTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactSubscriptionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ArtefactTemplateID { get; set; }

        [DataMember]
        public int ArtefactTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid PlanSubscriptionTemplateID { get; set; }

        [DataMember]
        public int PlanSubscriptionTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ArtefactTemplateDTO ArtefactTemplate { get; set; }

        #endregion
    }

}
