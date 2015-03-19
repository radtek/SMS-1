﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationGroupTemplateConverter
    {

        public static DefaultOrganisationGroupTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationGroupTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationGroupTemplateDTO();

            // Properties
            target.DefaultOrganisationGroupTemplateID = source.DefaultOrganisationGroupTemplateID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
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
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationGroupRoleTemplates = source.DefaultOrganisationGroupRoleTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.Group = source.Group.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationGroupTargetTemplates = source.DefaultOrganisationGroupTargetTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate ToEntity(this DefaultOrganisationGroupTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate();

            // Properties
            target.DefaultOrganisationGroupTemplateID = source.DefaultOrganisationGroupTemplateID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
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
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationGroupTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationGroupTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate> ToEntities(this IEnumerable<DefaultOrganisationGroupTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate source, DefaultOrganisationGroupTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationGroupTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationGroupTemplate target);

    }

}
