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
    public partial class VUserAccountNotLoggedInDTO
    {
        #region Constructors
  
        public VUserAccountNotLoggedInDTO() {
        }

        public VUserAccountNotLoggedInDTO(global::System.Guid iD, string username, string email, bool isTemporaryAccount, global::System.DateTime created, global::System.Nullable<double> daysSinceCreation, global::System.Nullable<double> hoursSinceCreation, global::System.Nullable<bool> between7and14DaysNotLoggedIn, global::System.Nullable<bool> between14and21DaysNotLoggedIn, global::System.Nullable<bool> between0and7DaysNotLoggedIn, global::System.Nullable<bool> greaterThan21DaysNotLoggedIn, global::System.Nullable<bool> notLoggedIn, global::System.Nullable<long> cOLPRemindersNotReadEver, global::System.Nullable<long> cOLPRegistrationsNotReadEver, global::System.Nullable<long> cOLPRemindersNotReadBetween7and14Days, global::System.Nullable<long> cOLPRemindersNotReadBetween14and21Days, global::System.Nullable<long> cOLPRemindersNotReadBetween0and7Days, string loginWorkflowDataContent) {

          this.ID = iD;
          this.Username = username;
          this.Email = email;
          this.IsTemporaryAccount = isTemporaryAccount;
          this.Created = created;
          this.DaysSinceCreation = daysSinceCreation;
          this.HoursSinceCreation = hoursSinceCreation;
          this.Between7and14DaysNotLoggedIn = between7and14DaysNotLoggedIn;
          this.Between14and21DaysNotLoggedIn = between14and21DaysNotLoggedIn;
          this.Between0and7DaysNotLoggedIn = between0and7DaysNotLoggedIn;
          this.GreaterThan21DaysNotLoggedIn = greaterThan21DaysNotLoggedIn;
          this.NotLoggedIn = notLoggedIn;
          this.COLPRemindersNotReadEver = cOLPRemindersNotReadEver;
          this.COLPRegistrationsNotReadEver = cOLPRegistrationsNotReadEver;
          this.COLPRemindersNotReadBetween7and14Days = cOLPRemindersNotReadBetween7and14Days;
          this.COLPRemindersNotReadBetween14and21Days = cOLPRemindersNotReadBetween14and21Days;
          this.COLPRemindersNotReadBetween0and7Days = cOLPRemindersNotReadBetween0and7Days;
          this.LoginWorkflowDataContent = loginWorkflowDataContent;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public bool IsTemporaryAccount { get; set; }

        [DataMember]
        public global::System.DateTime Created { get; set; }

        [DataMember]
        public global::System.Nullable<double> DaysSinceCreation { get; set; }

        [DataMember]
        public global::System.Nullable<double> HoursSinceCreation { get; set; }

        [DataMember]
        public global::System.Nullable<bool> Between7and14DaysNotLoggedIn { get; set; }

        [DataMember]
        public global::System.Nullable<bool> Between14and21DaysNotLoggedIn { get; set; }

        [DataMember]
        public global::System.Nullable<bool> Between0and7DaysNotLoggedIn { get; set; }

        [DataMember]
        public global::System.Nullable<bool> GreaterThan21DaysNotLoggedIn { get; set; }

        [DataMember]
        public global::System.Nullable<bool> NotLoggedIn { get; set; }

        [DataMember]
        public global::System.Nullable<long> COLPRemindersNotReadEver { get; set; }

        [DataMember]
        public global::System.Nullable<long> COLPRegistrationsNotReadEver { get; set; }

        [DataMember]
        public global::System.Nullable<long> COLPRemindersNotReadBetween7and14Days { get; set; }

        [DataMember]
        public global::System.Nullable<long> COLPRemindersNotReadBetween14and21Days { get; set; }

        [DataMember]
        public global::System.Nullable<long> COLPRemindersNotReadBetween0and7Days { get; set; }

        [DataMember]
        public string LoginWorkflowDataContent { get; set; }

        #endregion
    }

}
