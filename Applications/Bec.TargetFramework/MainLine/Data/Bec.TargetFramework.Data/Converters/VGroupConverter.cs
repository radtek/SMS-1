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

    public static partial class VGroupConverter
    {

        public static VGroupDTO ToDto(this Bec.TargetFramework.Data.VGroup source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VGroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VGroup source, int level)
        {
            if (source == null)
              return null;

            var target = new VGroupDTO();

            // Properties
            target.GroupID = source.GroupID;
            target.GroupName = source.GroupName;
            target.GroupDescription = source.GroupDescription;
            target.GroupTypeID = source.GroupTypeID;
            target.GroupSubTypeID = source.GroupSubTypeID;
            target.GroupCategoryID = source.GroupCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDisabled = source.IsDisabled;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VGroup ToEntity(this VGroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VGroup();

            // Properties
            target.GroupID = source.GroupID;
            target.GroupName = source.GroupName;
            target.GroupDescription = source.GroupDescription;
            target.GroupTypeID = source.GroupTypeID;
            target.GroupSubTypeID = source.GroupSubTypeID;
            target.GroupCategoryID = source.GroupCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDisabled = source.IsDisabled;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VGroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VGroup> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VGroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VGroup> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VGroup> ToEntities(this IEnumerable<VGroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VGroup source, VGroupDTO target);

        static partial void OnEntityCreating(VGroupDTO source, Bec.TargetFramework.Data.VGroup target);

    }

}