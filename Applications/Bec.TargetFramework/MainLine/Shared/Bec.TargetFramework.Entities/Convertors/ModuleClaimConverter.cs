﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModuleClaimConverter
    {

        public static ModuleClaimDTO ToDto(this Bec.TargetFramework.Data.ModuleClaim source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleClaimDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleClaim source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleClaimDTO();

            // Properties
            target.ClaimID = source.ClaimID;
            target.RoleID = source.RoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.ModuleID = source.ModuleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.ModuleRoleID = source.ModuleRoleID;

            // Navigation Properties
            if (level > 0) {
              target.Module = source.Module.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
              target.ModuleRole = source.ModuleRole.ToDtoWithRelated(level - 1);
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleClaim ToEntity(this ModuleClaimDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleClaim();

            // Properties
            target.ClaimID = source.ClaimID;
            target.RoleID = source.RoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.ModuleID = source.ModuleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.ModuleRoleID = source.ModuleRoleID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleClaimDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleClaim> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleClaimDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleClaim> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleClaim> ToEntities(this IEnumerable<ModuleClaimDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleClaim source, ModuleClaimDTO target);

        static partial void OnEntityCreating(ModuleClaimDTO source, Bec.TargetFramework.Data.ModuleClaim target);

    }

}
