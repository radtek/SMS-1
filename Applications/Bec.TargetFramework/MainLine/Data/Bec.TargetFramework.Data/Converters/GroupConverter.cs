﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class GroupConverter
    {

        public static GroupDTO ToDto(this Bec.TargetFramework.Data.Group source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static GroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Group source, int level)
        {
            if (source == null)
              return null;

            var target = new GroupDTO();

            // Properties
            target.GroupID = source.GroupID;
            target.GroupName = source.GroupName;
            target.GroupDescription = source.GroupDescription;
            target.GroupTypeID = source.GroupTypeID;
            target.GroupSubTypeID = source.GroupSubTypeID;
            target.GroupCategoryID = source.GroupCategoryID;
            target.GroupSubCategoryID = source.GroupSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationGroupTemplates = source.DefaultOrganisationGroupTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationGroups = source.DefaultOrganisationGroups.ToDtosWithRelated(level - 1);
              target.GroupRoles = source.GroupRoles.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Group ToEntity(this GroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Group();

            // Properties
            target.GroupID = source.GroupID;
            target.GroupName = source.GroupName;
            target.GroupDescription = source.GroupDescription;
            target.GroupTypeID = source.GroupTypeID;
            target.GroupSubTypeID = source.GroupSubTypeID;
            target.GroupCategoryID = source.GroupCategoryID;
            target.GroupSubCategoryID = source.GroupSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<GroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Group> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<GroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Group> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Group> ToEntities(this IEnumerable<GroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Group source, GroupDTO target);

        static partial void OnEntityCreating(GroupDTO source, Bec.TargetFramework.Data.Group target);

    }

}