﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationRoleClaimTemplateConverter
    {

        public static DefaultOrganisationRoleClaimTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationRoleClaimTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationRoleClaimTemplateDTO();

            // Properties
            target.DefaultOrganisationRoleClaimTemplateID = source.DefaultOrganisationRoleClaimTemplateID;
            target.DefaultOrganisationRoleTemplateID = source.DefaultOrganisationRoleTemplateID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationRoleTemplate = source.DefaultOrganisationRoleTemplate.ToDtoWithRelated(level - 1);
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate ToEntity(this DefaultOrganisationRoleClaimTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate();

            // Properties
            target.DefaultOrganisationRoleClaimTemplateID = source.DefaultOrganisationRoleClaimTemplateID;
            target.DefaultOrganisationRoleTemplateID = source.DefaultOrganisationRoleTemplateID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationRoleClaimTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationRoleClaimTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate> ToEntities(this IEnumerable<DefaultOrganisationRoleClaimTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate source, DefaultOrganisationRoleClaimTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationRoleClaimTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate target);

    }

}
