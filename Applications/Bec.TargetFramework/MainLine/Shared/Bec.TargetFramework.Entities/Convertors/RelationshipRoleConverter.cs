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

    public static partial class RelationshipRoleConverter
    {

        public static RelationshipRoleDTO ToDto(this Bec.TargetFramework.Data.RelationshipRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static RelationshipRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.RelationshipRole source, int level)
        {
            if (source == null)
              return null;

            var target = new RelationshipRoleDTO();

            // Properties
            target.RelationshipRoleID = source.RelationshipRoleID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.RelationshipRoleStatusID = source.RelationshipRoleStatusID;
            target.RelationshipRoleStateID = source.RelationshipRoleStateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.RelationshipRole ToEntity(this RelationshipRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.RelationshipRole();

            // Properties
            target.RelationshipRoleID = source.RelationshipRoleID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.RelationshipRoleStatusID = source.RelationshipRoleStatusID;
            target.RelationshipRoleStateID = source.RelationshipRoleStateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<RelationshipRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.RelationshipRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<RelationshipRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.RelationshipRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.RelationshipRole> ToEntities(this IEnumerable<RelationshipRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.RelationshipRole source, RelationshipRoleDTO target);

        static partial void OnEntityCreating(RelationshipRoleDTO source, Bec.TargetFramework.Data.RelationshipRole target);

    }

}
