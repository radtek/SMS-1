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
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VNotificationRecipientStatusConverter
    {

        public static VNotificationRecipientStatusDTO ToDto(this Bec.TargetFramework.Data.VNotificationRecipientStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VNotificationRecipientStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VNotificationRecipientStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new VNotificationRecipientStatusDTO();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.NotificationID = source.NotificationID;
            target.NotificationStatusID = source.NotificationStatusID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.NotificationDeliveryMethodID = source.NotificationDeliveryMethodID;
            target.NotificationExportFormatID = source.NotificationExportFormatID;
            target.DateSent = source.DateSent;
            target.IsSent = source.IsSent;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAccepted = source.IsAccepted;
            target.AcceptedDate = source.AcceptedDate;
            target.IsRead = source.IsRead;
            target.CreatedOn = source.CreatedOn;
            target.ErrorOccured = source.ErrorOccured;
            target.SentOn = source.SentOn;
            target.NotificationVerificationCode = source.NotificationVerificationCode;
            target.NotificationRecipientID = source.NotificationRecipientID;
            target.NotificationRecipientLogID = source.NotificationRecipientLogID;
            target.OrganisationID = source.OrganisationID;
            target.RecipientParent = source.RecipientParent;
            target.RecipientToParent = source.RecipientToParent;
            target.ParentID = source.ParentID;
            target.FromParentID = source.FromParentID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VNotificationRecipientStatus ToEntity(this VNotificationRecipientStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VNotificationRecipientStatus();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.NotificationID = source.NotificationID;
            target.NotificationStatusID = source.NotificationStatusID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.NotificationDeliveryMethodID = source.NotificationDeliveryMethodID;
            target.NotificationExportFormatID = source.NotificationExportFormatID;
            target.DateSent = source.DateSent;
            target.IsSent = source.IsSent;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAccepted = source.IsAccepted;
            target.AcceptedDate = source.AcceptedDate;
            target.IsRead = source.IsRead;
            target.CreatedOn = source.CreatedOn;
            target.ErrorOccured = source.ErrorOccured;
            target.SentOn = source.SentOn;
            target.NotificationVerificationCode = source.NotificationVerificationCode;
            target.NotificationRecipientID = source.NotificationRecipientID;
            target.NotificationRecipientLogID = source.NotificationRecipientLogID;
            target.OrganisationID = source.OrganisationID;
            target.RecipientParent = source.RecipientParent;
            target.RecipientToParent = source.RecipientToParent;
            target.ParentID = source.ParentID;
            target.FromParentID = source.FromParentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VNotificationRecipientStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VNotificationRecipientStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VNotificationRecipientStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VNotificationRecipientStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VNotificationRecipientStatus> ToEntities(this IEnumerable<VNotificationRecipientStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VNotificationRecipientStatus source, VNotificationRecipientStatusDTO target);

        static partial void OnEntityCreating(VNotificationRecipientStatusDTO source, Bec.TargetFramework.Data.VNotificationRecipientStatus target);

    }

}
