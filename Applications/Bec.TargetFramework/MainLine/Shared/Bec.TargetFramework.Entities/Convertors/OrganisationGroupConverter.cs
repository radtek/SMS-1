﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationGroupConverter
    {

        public static OrganisationGroupDTO ToDto(this Bec.TargetFramework.Data.OrganisationGroup source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationGroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationGroup source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationGroupDTO();

            // Properties
            target.OrganisationGroupID = source.OrganisationGroupID;
            target.GroupName = source.GroupName;
            target.OrganisationID = source.OrganisationID;
            target.ParentID = source.ParentID;
            target.ParentOrganisationGroupID = source.ParentOrganisationGroupID;
            target.ParentRootGroupID = source.ParentRootGroupID;
            target.IsManaged = source.IsManaged;
            target.GroupTypeID = source.GroupTypeID;
            target.GroupSubTypeID = source.GroupSubTypeID;
            target.GroupCategoryID = source.GroupCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.GroupDescription = source.GroupDescription;
            target.GroupSubCategoryID = source.GroupSubCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationGroupRoles = source.OrganisationGroupRoles.ToDtosWithRelated(level - 1);
              target.OrganisationUnitOrganisationGroups = source.OrganisationUnitOrganisationGroups.ToDtosWithRelated(level - 1);
              target.RepositoryStructureGroups = source.RepositoryStructureGroups.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisationGroups = source.UserAccountOrganisationGroups.ToDtosWithRelated(level - 1);
              target.AttachmentDetailGroups = source.AttachmentDetailGroups.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationGroup ToEntity(this OrganisationGroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationGroup();

            // Properties
            target.OrganisationGroupID = source.OrganisationGroupID;
            target.GroupName = source.GroupName;
            target.OrganisationID = source.OrganisationID;
            target.ParentID = source.ParentID;
            target.ParentOrganisationGroupID = source.ParentOrganisationGroupID;
            target.ParentRootGroupID = source.ParentRootGroupID;
            target.IsManaged = source.IsManaged;
            target.GroupTypeID = source.GroupTypeID;
            target.GroupSubTypeID = source.GroupSubTypeID;
            target.GroupCategoryID = source.GroupCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.GroupDescription = source.GroupDescription;
            target.GroupSubCategoryID = source.GroupSubCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationGroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationGroup> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationGroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationGroup> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationGroup> ToEntities(this IEnumerable<OrganisationGroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationGroup source, OrganisationGroupDTO target);

        static partial void OnEntityCreating(OrganisationGroupDTO source, Bec.TargetFramework.Data.OrganisationGroup target);

    }

}
