﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModuleClaimTemplateConverter
    {

        public static ModuleClaimTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleClaimTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleClaimTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleClaimTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleClaimTemplateDTO();

            // Properties
            target.ClaimID = source.ClaimID;
            target.RoleID = source.RoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.ModuleRoleID = source.ModuleRoleID;

            // Navigation Properties
            if (level > 0) {
              target.ModuleTemplate = source.ModuleTemplate.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
              target.ModuleRoleTemplate = source.ModuleRoleTemplate.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleClaimTemplate ToEntity(this ModuleClaimTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleClaimTemplate();

            // Properties
            target.ClaimID = source.ClaimID;
            target.RoleID = source.RoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.ModuleRoleID = source.ModuleRoleID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleClaimTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleClaimTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleClaimTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleClaimTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleClaimTemplate> ToEntities(this IEnumerable<ModuleClaimTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleClaimTemplate source, ModuleClaimTemplateDTO target);

        static partial void OnEntityCreating(ModuleClaimTemplateDTO source, Bec.TargetFramework.Data.ModuleClaimTemplate target);

    }

}
