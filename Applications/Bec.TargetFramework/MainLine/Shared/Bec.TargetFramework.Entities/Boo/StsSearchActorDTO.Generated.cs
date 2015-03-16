﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class StsSearchActorDTO
    {
        #region Constructors
  
        public StsSearchActorDTO() {
        }

        public StsSearchActorDTO(global::System.Guid stsSearchID, global::System.Nullable<System.Guid> organisationID, global::System.Guid actorID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> primaryUserAccountOrganisationID, global::System.Guid stsSearchActorID, global::System.Guid stsInviteID, bool isInviteActive, bool isOrganisatonPersonal, global::System.Nullable<System.Guid> temporaryActorContactID, global::System.Nullable<bool> hasDeclarationBeenAccepted, List<StsSearchAccountDTO> stsSearchAccounts, List<StsSearchActorDetailDTO> stsSearchActorDetails, List<StsSearchActorProcessLogDTO> stsSearchActorProcessLogs, List<StsSearchActorStructureDTO> stsSearchActorStructures_PrimaryStsSearchActorID, List<StsSearchActorStructureDTO> stsSearchActorStructures_SecondaryStsSearchActorID, StsSearchDTO stsSearch, StsInviteDTO stsInvite, ContactDTO contact, ActorDTO actor, OrganisationDTO organisation, UserAccountOrganisationDTO userAccountOrganisation, List<StsSearchLRDocumentOrderDTO> stsSearchLRDocumentOrders) {

          this.StsSearchID = stsSearchID;
          this.OrganisationID = organisationID;
          this.ActorID = actorID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PrimaryUserAccountOrganisationID = primaryUserAccountOrganisationID;
          this.StsSearchActorID = stsSearchActorID;
          this.StsInviteID = stsInviteID;
          this.IsInviteActive = isInviteActive;
          this.IsOrganisatonPersonal = isOrganisatonPersonal;
          this.TemporaryActorContactID = temporaryActorContactID;
          this.HasDeclarationBeenAccepted = hasDeclarationBeenAccepted;
          this.StsSearchAccounts = stsSearchAccounts;
          this.StsSearchActorDetails = stsSearchActorDetails;
          this.StsSearchActorProcessLogs = stsSearchActorProcessLogs;
          this.StsSearchActorStructures_PrimaryStsSearchActorID = stsSearchActorStructures_PrimaryStsSearchActorID;
          this.StsSearchActorStructures_SecondaryStsSearchActorID = stsSearchActorStructures_SecondaryStsSearchActorID;
          this.StsSearch = stsSearch;
          this.StsInvite = stsInvite;
          this.Contact = contact;
          this.Actor = actor;
          this.Organisation = organisation;
          this.UserAccountOrganisation = userAccountOrganisation;
          this.StsSearchLRDocumentOrders = stsSearchLRDocumentOrders;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StsSearchID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid ActorID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> PrimaryUserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid StsSearchActorID { get; set; }

        [DataMember]
        public global::System.Guid StsInviteID { get; set; }

        [DataMember]
        public bool IsInviteActive { get; set; }

        [DataMember]
        public bool IsOrganisatonPersonal { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> TemporaryActorContactID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> HasDeclarationBeenAccepted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<StsSearchAccountDTO> StsSearchAccounts { get; set; }

        [DataMember]
        public List<StsSearchActorDetailDTO> StsSearchActorDetails { get; set; }

        [DataMember]
        public List<StsSearchActorProcessLogDTO> StsSearchActorProcessLogs { get; set; }

        [DataMember]
        public List<StsSearchActorStructureDTO> StsSearchActorStructures_PrimaryStsSearchActorID { get; set; }

        [DataMember]
        public List<StsSearchActorStructureDTO> StsSearchActorStructures_SecondaryStsSearchActorID { get; set; }

        [DataMember]
        public StsSearchDTO StsSearch { get; set; }

        [DataMember]
        public StsInviteDTO StsInvite { get; set; }

        [DataMember]
        public ContactDTO Contact { get; set; }

        [DataMember]
        public ActorDTO Actor { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        [DataMember]
        public List<StsSearchLRDocumentOrderDTO> StsSearchLRDocumentOrders { get; set; }

        #endregion
    }

}
