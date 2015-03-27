﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ActorConverter
    {

        public static ActorDTO ToDto(this Bec.TargetFramework.Data.Actor source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ActorDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Actor source, int level)
        {
            if (source == null)
              return null;

            var target = new ActorDTO();

            // Properties
            target.ActorID = source.ActorID;
            target.ActorName = source.ActorName;
            target.ActorDescription = source.ActorDescription;
            target.ActorTypeID = source.ActorTypeID;
            target.ActorSubTypeID = source.ActorSubTypeID;
            target.ActorCategoryID = source.ActorCategoryID;
            target.ActorSubCategoryID = source.ActorSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;

            // Navigation Properties
            if (level > 0) {
              target.ActorClaimRoleMappings = source.ActorClaimRoleMappings.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Actor ToEntity(this ActorDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Actor();

            // Properties
            target.ActorID = source.ActorID;
            target.ActorName = source.ActorName;
            target.ActorDescription = source.ActorDescription;
            target.ActorTypeID = source.ActorTypeID;
            target.ActorSubTypeID = source.ActorSubTypeID;
            target.ActorCategoryID = source.ActorCategoryID;
            target.ActorSubCategoryID = source.ActorSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ActorDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Actor> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ActorDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Actor> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Actor> ToEntities(this IEnumerable<ActorDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Actor source, ActorDTO target);

        static partial void OnEntityCreating(ActorDTO source, Bec.TargetFramework.Data.Actor target);

    }

}
