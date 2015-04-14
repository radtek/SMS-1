﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class StsInviteProcessLogConverter
    {

        public static StsInviteProcessLogDTO ToDto(this Bec.TargetFramework.Data.StsInviteProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StsInviteProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StsInviteProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new StsInviteProcessLogDTO();

            // Properties
            target.StsInviteID = source.StsInviteID;
            target.CreatedOn = source.CreatedOn;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsCancelled = source.IsCancelled;
            target.IsClosed = source.IsClosed;
            target.IsRejected = source.IsRejected;
            target.RejectReasonTypeID = source.RejectReasonTypeID;
            target.RejectReasonComments = source.RejectReasonComments;

            // Navigation Properties
            if (level > 0) {
              target.StsInvite = source.StsInvite.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StsInviteProcessLog ToEntity(this StsInviteProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StsInviteProcessLog();

            // Properties
            target.StsInviteID = source.StsInviteID;
            target.CreatedOn = source.CreatedOn;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsCancelled = source.IsCancelled;
            target.IsClosed = source.IsClosed;
            target.IsRejected = source.IsRejected;
            target.RejectReasonTypeID = source.RejectReasonTypeID;
            target.RejectReasonComments = source.RejectReasonComments;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StsInviteProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StsInviteProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StsInviteProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StsInviteProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StsInviteProcessLog> ToEntities(this IEnumerable<StsInviteProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StsInviteProcessLog source, StsInviteProcessLogDTO target);

        static partial void OnEntityCreating(StsInviteProcessLogDTO source, Bec.TargetFramework.Data.StsInviteProcessLog target);

    }

}
