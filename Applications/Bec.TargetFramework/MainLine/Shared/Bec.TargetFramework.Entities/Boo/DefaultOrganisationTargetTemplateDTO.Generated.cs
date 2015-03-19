﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class DefaultOrganisationTargetTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationTargetTemplateDTO() {
        }

        public DefaultOrganisationTargetTemplateDTO(global::System.Guid defaultOrganisationTargetTemplateID, int organisationTypeID, global::System.Nullable<int> organisationSubTypeID, global::System.Nullable<int> organisationCategoryID, global::System.Nullable<int> organisationSubCategoryID, global::System.Guid defaultOrganisationTemplateID, bool isActive, bool isDeleted, int defaultOrganisationTemplateVersionNumber, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, DefaultOrganisationStatusTypeTemplateDTO defaultOrganisationStatusTypeTemplate, DefaultOrganisationTemplateDTO defaultOrganisationTemplate, OrganisationTypeDTO organisationType) {

          this.DefaultOrganisationTargetTemplateID = defaultOrganisationTargetTemplateID;
          this.OrganisationTypeID = organisationTypeID;
          this.OrganisationSubTypeID = organisationSubTypeID;
          this.OrganisationCategoryID = organisationCategoryID;
          this.OrganisationSubCategoryID = organisationSubCategoryID;
          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.DefaultOrganisationStatusTypeTemplate = defaultOrganisationStatusTypeTemplate;
          this.DefaultOrganisationTemplate = defaultOrganisationTemplate;
          this.OrganisationType = organisationType;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationTargetTemplateID { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationSubCategoryID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int DefaultOrganisationTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationStatusTypeTemplateDTO DefaultOrganisationStatusTypeTemplate { get; set; }

        [DataMember]
        public DefaultOrganisationTemplateDTO DefaultOrganisationTemplate { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        #endregion
    }

}
