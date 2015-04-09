﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class ModuleSubscriptionDTO
    {
        #region Constructors
  
        public ModuleSubscriptionDTO() {
        }

        public ModuleSubscriptionDTO(global::System.Guid moduleSubscriptionID, global::System.Guid moduleID, int moduleVersionNumber, bool isActive, bool isDeleted, global::System.Guid planSubscriptionID, int planSubscriptionVersionNumber, ModuleDTO module, PlanSubscriptionDTO planSubscription) {

          this.ModuleSubscriptionID = moduleSubscriptionID;
          this.ModuleID = moduleID;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PlanSubscriptionID = planSubscriptionID;
          this.PlanSubscriptionVersionNumber = planSubscriptionVersionNumber;
          this.Module = module;
          this.PlanSubscription = planSubscription;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleSubscriptionID { get; set; }

        [DataMember]
        public global::System.Guid ModuleID { get; set; }

        [DataMember]
        public int ModuleVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid PlanSubscriptionID { get; set; }

        [DataMember]
        public int PlanSubscriptionVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleDTO Module { get; set; }

        [DataMember]
        public PlanSubscriptionDTO PlanSubscription { get; set; }

        #endregion
    }

}
