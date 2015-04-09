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
    public partial class DefaultOrganisationArtefactDTO
    {
        #region Constructors
  
        public DefaultOrganisationArtefactDTO() {
        }

        public DefaultOrganisationArtefactDTO(global::System.Guid defaultOrganisationID, global::System.Guid artefactID, int artefactVersionNumber, global::System.Guid parentID, bool isActive, bool isDeleted, int defaultOrganisationVersionNumber, ArtefactDTO artefact, DefaultOrganisationDTO defaultOrganisation) {

          this.DefaultOrganisationID = defaultOrganisationID;
          this.ArtefactID = artefactID;
          this.ArtefactVersionNumber = artefactVersionNumber;
          this.ParentID = parentID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.Artefact = artefact;
          this.DefaultOrganisation = defaultOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid ArtefactID { get; set; }

        [DataMember]
        public int ArtefactVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ArtefactDTO Artefact { get; set; }

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        #endregion
    }

}
