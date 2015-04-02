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

    public static partial class ActorClaimRoleMappingConverter
    {

        public static ActorClaimRoleMappingDTO ToDto(this Bec.TargetFramework.Data.ActorClaimRoleMapping source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ActorClaimRoleMappingDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ActorClaimRoleMapping source, int level)
        {
            if (source == null)
              return null;

            var target = new ActorClaimRoleMappingDTO();

            // Properties
            target.ActorClaimRoleMappingID = source.ActorClaimRoleMappingID;
            target.ActorID = source.ActorID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.RoleID = source.RoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Actor = source.Actor.ToDtoWithRelated(level - 1);
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ActorClaimRoleMapping ToEntity(this ActorClaimRoleMappingDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ActorClaimRoleMapping();

            // Properties
            target.ActorClaimRoleMappingID = source.ActorClaimRoleMappingID;
            target.ActorID = source.ActorID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.RoleID = source.RoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ActorClaimRoleMappingDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ActorClaimRoleMapping> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ActorClaimRoleMappingDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ActorClaimRoleMapping> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ActorClaimRoleMapping> ToEntities(this IEnumerable<ActorClaimRoleMappingDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ActorClaimRoleMapping source, ActorClaimRoleMappingDTO target);

        static partial void OnEntityCreating(ActorClaimRoleMappingDTO source, Bec.TargetFramework.Data.ActorClaimRoleMapping target);

    }

}
