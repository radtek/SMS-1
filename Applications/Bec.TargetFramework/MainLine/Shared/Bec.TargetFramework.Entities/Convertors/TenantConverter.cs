﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class TenantConverter
    {

        public static TenantDTO ToDto(this Bec.TargetFramework.Data.Tenant source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TenantDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Tenant source, int level)
        {
            if (source == null)
              return null;

            var target = new TenantDTO();

            // Properties
            target.TenantID = source.TenantID;
            target.TenantName = source.TenantName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Tenant ToEntity(this TenantDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Tenant();

            // Properties
            target.TenantID = source.TenantID;
            target.TenantName = source.TenantName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TenantDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Tenant> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TenantDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Tenant> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Tenant> ToEntities(this IEnumerable<TenantDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Tenant source, TenantDTO target);

        static partial void OnEntityCreating(TenantDTO source, Bec.TargetFramework.Data.Tenant target);

    }

}
