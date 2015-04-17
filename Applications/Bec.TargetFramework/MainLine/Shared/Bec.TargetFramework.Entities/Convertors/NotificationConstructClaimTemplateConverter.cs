﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class NotificationConstructClaimTemplateConverter
    {

        public static NotificationConstructClaimTemplateDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructClaimTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructClaimTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructClaimTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructClaimTemplateDTO();

            // Properties
            target.NotificationConstructClaimTemplateID = source.NotificationConstructClaimTemplateID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.NotificationConstructRoleID = source.NotificationConstructRoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleID = source.RoleID;

            // Navigation Properties
            if (level > 0) {
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
              target.NotificationConstructTemplate = source.NotificationConstructTemplate.ToDtoWithRelated(level - 1);
              target.NotificationConstructRoleTemplate = source.NotificationConstructRoleTemplate.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructClaimTemplate ToEntity(this NotificationConstructClaimTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructClaimTemplate();

            // Properties
            target.NotificationConstructClaimTemplateID = source.NotificationConstructClaimTemplateID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.NotificationConstructRoleID = source.NotificationConstructRoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleID = source.RoleID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructClaimTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructClaimTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructClaimTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructClaimTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructClaimTemplate> ToEntities(this IEnumerable<NotificationConstructClaimTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructClaimTemplate source, NotificationConstructClaimTemplateDTO target);

        static partial void OnEntityCreating(NotificationConstructClaimTemplateDTO source, Bec.TargetFramework.Data.NotificationConstructClaimTemplate target);

    }

}
