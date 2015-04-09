﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class UserAccountArchiveConverter
    {

        public static UserAccountArchiveDTO ToDto(this Bec.TargetFramework.Data.UserAccountArchive source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountArchiveDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountArchive source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountArchiveDTO();

            // Properties
            target.UserAccountArchiveID = source.UserAccountArchiveID;
            target.UserAccountArchiveCreatedOn = source.UserAccountArchiveCreatedOn;
            target.UserAccountArchiveTypeID = source.UserAccountArchiveTypeID;
            target.UserAccountArchiveCategoryID = source.UserAccountArchiveCategoryID;
            target.UserAccountArchiveData = source.UserAccountArchiveData;
            target.UserAccountArchiveVersionID = source.UserAccountArchiveVersionID;
            target.UserAccountArchiveStartDate = source.UserAccountArchiveStartDate;
            target.UserAccountArchiveEndDate = source.UserAccountArchiveEndDate;
            target.UserID = source.UserID;

            // Navigation Properties
            if (level > 0) {
              target.UserAccount = source.UserAccount.ToDtoWithRelated(level - 1);
              target.ClassificationType = source.ClassificationType.ToDtoWithRelated(level - 1);
              target.ClassificationTypeCategory = source.ClassificationTypeCategory.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountArchive ToEntity(this UserAccountArchiveDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountArchive();

            // Properties
            target.UserAccountArchiveID = source.UserAccountArchiveID;
            target.UserAccountArchiveCreatedOn = source.UserAccountArchiveCreatedOn;
            target.UserAccountArchiveTypeID = source.UserAccountArchiveTypeID;
            target.UserAccountArchiveCategoryID = source.UserAccountArchiveCategoryID;
            target.UserAccountArchiveData = source.UserAccountArchiveData;
            target.UserAccountArchiveVersionID = source.UserAccountArchiveVersionID;
            target.UserAccountArchiveStartDate = source.UserAccountArchiveStartDate;
            target.UserAccountArchiveEndDate = source.UserAccountArchiveEndDate;
            target.UserID = source.UserID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountArchiveDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountArchive> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountArchiveDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountArchive> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountArchive> ToEntities(this IEnumerable<UserAccountArchiveDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountArchive source, UserAccountArchiveDTO target);

        static partial void OnEntityCreating(UserAccountArchiveDTO source, Bec.TargetFramework.Data.UserAccountArchive target);

    }

}
