﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class OrganisationPlanSubscriptionDTO
    {
        #region Constructors
  
        public OrganisationPlanSubscriptionDTO() {
        }

        public OrganisationPlanSubscriptionDTO(global::System.Guid organisationID, global::System.Guid planSubscriptionID, int planSubscriptionVersionNumber, bool isActive, bool isDeleted, PlanSubscriptionDTO planSubscription, OrganisationDTO organisation) {

          this.OrganisationID = organisationID;
          this.PlanSubscriptionID = planSubscriptionID;
          this.PlanSubscriptionVersionNumber = planSubscriptionVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PlanSubscription = planSubscription;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid PlanSubscriptionID { get; set; }

        [DataMember]
        public int PlanSubscriptionVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PlanSubscriptionDTO PlanSubscription { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
