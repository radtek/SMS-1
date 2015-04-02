﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class StatusTypeClaimConverter
    {

        public static StatusTypeClaimDTO ToDto(this Bec.TargetFramework.Data.StatusTypeClaim source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeClaimDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StatusTypeClaim source, int level)
        {
            if (source == null)
              return null;

            var target = new StatusTypeClaimDTO();

            // Properties
            target.StatusTypeClaimID = source.StatusTypeClaimID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleID = source.RoleID;
            target.StatusTypeRoleID = source.StatusTypeRoleID;

            // Navigation Properties
            if (level > 0) {
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeRole = source.StatusTypeRole.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StatusTypeClaim ToEntity(this StatusTypeClaimDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StatusTypeClaim();

            // Properties
            target.StatusTypeClaimID = source.StatusTypeClaimID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleID = source.RoleID;
            target.StatusTypeRoleID = source.StatusTypeRoleID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StatusTypeClaimDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StatusTypeClaim> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeClaimDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StatusTypeClaim> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StatusTypeClaim> ToEntities(this IEnumerable<StatusTypeClaimDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StatusTypeClaim source, StatusTypeClaimDTO target);

        static partial void OnEntityCreating(StatusTypeClaimDTO source, Bec.TargetFramework.Data.StatusTypeClaim target);

    }

}
