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

    public static partial class LenderConverter
    {

        public static LenderDTO ToDto(this Bec.TargetFramework.Data.Lender source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LenderDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Lender source, int level)
        {
            if (source == null)
              return null;

            var target = new LenderDTO();

            // Properties
            target.LenderID = source.LenderID;
            target.Name = source.Name;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Lender ToEntity(this LenderDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Lender();

            // Properties
            target.LenderID = source.LenderID;
            target.Name = source.Name;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LenderDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Lender> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LenderDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Lender> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Lender> ToEntities(this IEnumerable<LenderDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Lender source, LenderDTO target);

        static partial void OnEntityCreating(LenderDTO source, Bec.TargetFramework.Data.Lender target);

    }

}
