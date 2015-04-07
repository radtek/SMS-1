﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
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
    public partial class PlanGroupDTO
    {
        #region Constructors
  
        public PlanGroupDTO() {
        }

        public PlanGroupDTO(int planGroupID, string name, string description, global::System.Nullable<System.Guid> parentID, bool hasSameGlobalPaymentMethodForAllPlans, List<PlanTemplateDTO> planTemplates, List<PlanDTO> plans) {

          this.PlanGroupID = planGroupID;
          this.Name = name;
          this.Description = description;
          this.ParentID = parentID;
          this.HasSameGlobalPaymentMethodForAllPlans = hasSameGlobalPaymentMethodForAllPlans;
          this.PlanTemplates = planTemplates;
          this.Plans = plans;
        }

        #endregion

        #region Properties

        [DataMember]
        public int PlanGroupID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public bool HasSameGlobalPaymentMethodForAllPlans { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<PlanTemplateDTO> PlanTemplates { get; set; }

        [DataMember]
        public List<PlanDTO> Plans { get; set; }

        #endregion
    }

}
