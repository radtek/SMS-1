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

    public static partial class VNotificationWithUAOVerificationCodeConverter
    {

        public static VNotificationWithUAOVerificationCodeDTO ToDto(this Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VNotificationWithUAOVerificationCodeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode source, int level)
        {
            if (source == null)
              return null;

            var target = new VNotificationWithUAOVerificationCodeDTO();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.NotificationID = source.NotificationID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.GroupName = source.GroupName;
            target.GroupDescription = source.GroupDescription;
            target.NotificationConstructName = source.NotificationConstructName;
            target.NotificationConstructSubject = source.NotificationConstructSubject;
            target.NotificationConstructTitle = source.NotificationConstructTitle;
            target.DateSent = source.DateSent;
            target.IsSent = source.IsSent;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAccepted = source.IsAccepted;
            target.AcceptedDate = source.AcceptedDate;
            target.UserTypeID = source.UserTypeID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.IsRead = source.IsRead;
            target.CreatedOn = source.CreatedOn;
            target.ErrorOccured = source.ErrorOccured;
            target.SentOn = source.SentOn;
            target.NotificationVerificationCode = source.NotificationVerificationCode;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode ToEntity(this VNotificationWithUAOVerificationCodeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.NotificationID = source.NotificationID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.GroupName = source.GroupName;
            target.GroupDescription = source.GroupDescription;
            target.NotificationConstructName = source.NotificationConstructName;
            target.NotificationConstructSubject = source.NotificationConstructSubject;
            target.NotificationConstructTitle = source.NotificationConstructTitle;
            target.DateSent = source.DateSent;
            target.IsSent = source.IsSent;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAccepted = source.IsAccepted;
            target.AcceptedDate = source.AcceptedDate;
            target.UserTypeID = source.UserTypeID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.IsRead = source.IsRead;
            target.CreatedOn = source.CreatedOn;
            target.ErrorOccured = source.ErrorOccured;
            target.SentOn = source.SentOn;
            target.NotificationVerificationCode = source.NotificationVerificationCode;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VNotificationWithUAOVerificationCodeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VNotificationWithUAOVerificationCodeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode> ToEntities(this IEnumerable<VNotificationWithUAOVerificationCodeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode source, VNotificationWithUAOVerificationCodeDTO target);

        static partial void OnEntityCreating(VNotificationWithUAOVerificationCodeDTO source, Bec.TargetFramework.Data.VNotificationWithUAOVerificationCode target);

    }

}
