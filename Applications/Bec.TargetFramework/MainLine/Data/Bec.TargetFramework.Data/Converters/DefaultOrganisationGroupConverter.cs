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

    public static partial class DefaultOrganisationGroupConverter
    {

        public static DefaultOrganisationGroupDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationGroup source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationGroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationGroup source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationGroupDTO();

            // Properties
            target.DefaultOrganisationGroupID = source.DefaultOrganisationGroupID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.GroupName = source.GroupName;
            target.GroupDescription = source.GroupDescription;
            target.GroupTypeID = source.GroupTypeID;
            target.GroupSubTypeID = source.GroupSubTypeID;
            target.GroupCategoryID = source.GroupCategoryID;
            target.GroupSubCategoryID = source.GroupSubCategoryID;
            target.ParentID = source.ParentID;
            target.GroupID = source.GroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDefaultOrganisationSpecific = source.IsDefaultOrganisationSpecific;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationGroupTargets = source.DefaultOrganisationGroupTargets.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationGroupRoles = source.DefaultOrganisationGroupRoles.ToDtosWithRelated(level - 1);
              target.Group = source.Group.ToDtoWithRelated(level - 1);
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationGroup ToEntity(this DefaultOrganisationGroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationGroup();

            // Properties
            target.DefaultOrganisationGroupID = source.DefaultOrganisationGroupID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.GroupName = source.GroupName;
            target.GroupDescription = source.GroupDescription;
            target.GroupTypeID = source.GroupTypeID;
            target.GroupSubTypeID = source.GroupSubTypeID;
            target.GroupCategoryID = source.GroupCategoryID;
            target.GroupSubCategoryID = source.GroupSubCategoryID;
            target.ParentID = source.ParentID;
            target.GroupID = source.GroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDefaultOrganisationSpecific = source.IsDefaultOrganisationSpecific;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationGroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationGroup> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationGroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationGroup> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationGroup> ToEntities(this IEnumerable<DefaultOrganisationGroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationGroup source, DefaultOrganisationGroupDTO target);

        static partial void OnEntityCreating(DefaultOrganisationGroupDTO source, Bec.TargetFramework.Data.DefaultOrganisationGroup target);

    }

}