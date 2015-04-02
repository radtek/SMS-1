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

    public static partial class RepositoryStructureConverter
    {

        public static RepositoryStructureDTO ToDto(this Bec.TargetFramework.Data.RepositoryStructure source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static RepositoryStructureDTO ToDtoWithRelated(this Bec.TargetFramework.Data.RepositoryStructure source, int level)
        {
            if (source == null)
              return null;

            var target = new RepositoryStructureDTO();

            // Properties
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.RepositoryID = source.RepositoryID;
            target.OwnerID = source.OwnerID;
            target.ParentRepositoryStructureID = source.ParentRepositoryStructureID;
            target.IsLeafNode = source.IsLeafNode;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.AttachmentDetails = source.AttachmentDetails.ToDtosWithRelated(level - 1);
              target.RepositoryStructureGroups = source.RepositoryStructureGroups.ToDtosWithRelated(level - 1);
              target.RepositoryStructureRoles = source.RepositoryStructureRoles.ToDtosWithRelated(level - 1);
              target.Repository = source.Repository.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.RepositoryStructure ToEntity(this RepositoryStructureDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.RepositoryStructure();

            // Properties
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.RepositoryID = source.RepositoryID;
            target.OwnerID = source.OwnerID;
            target.ParentRepositoryStructureID = source.ParentRepositoryStructureID;
            target.IsLeafNode = source.IsLeafNode;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<RepositoryStructureDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.RepositoryStructure> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<RepositoryStructureDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.RepositoryStructure> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.RepositoryStructure> ToEntities(this IEnumerable<RepositoryStructureDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.RepositoryStructure source, RepositoryStructureDTO target);

        static partial void OnEntityCreating(RepositoryStructureDTO source, Bec.TargetFramework.Data.RepositoryStructure target);

    }

}
