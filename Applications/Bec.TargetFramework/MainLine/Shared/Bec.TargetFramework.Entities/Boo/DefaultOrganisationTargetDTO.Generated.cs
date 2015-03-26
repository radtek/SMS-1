﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class DefaultOrganisationTargetDTO
    {
        #region Constructors
  
        public DefaultOrganisationTargetDTO() {
        }

        public DefaultOrganisationTargetDTO(global::System.Guid defaultOrganisationTargetID, int organisationTypeID, global::System.Nullable<int> organisationSubTypeID, global::System.Nullable<int> organisationCategoryID, global::System.Nullable<int> organisationSubCategoryID, global::System.Guid defaultOrganisationID, bool isActive, bool isDeleted, int defaultOrganisationVersionNumber, global::System.Guid statusTypeID, int statusTypeVersionNumber, DefaultOrganisationDTO defaultOrganisation, DefaultOrganisationStatusTypeDTO defaultOrganisationStatusType, OrganisationTypeDTO organisationType) {

          this.DefaultOrganisationTargetID = defaultOrganisationTargetID;
          this.OrganisationTypeID = organisationTypeID;
          this.OrganisationSubTypeID = organisationSubTypeID;
          this.OrganisationCategoryID = organisationCategoryID;
          this.OrganisationSubCategoryID = organisationSubCategoryID;
          this.DefaultOrganisationID = defaultOrganisationID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.DefaultOrganisation = defaultOrganisation;
          this.DefaultOrganisationStatusType = defaultOrganisationStatusType;
          this.OrganisationType = organisationType;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationTargetID { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationSubCategoryID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        [DataMember]
        public DefaultOrganisationStatusTypeDTO DefaultOrganisationStatusType { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        #endregion
    }

}
