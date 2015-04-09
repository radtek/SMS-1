﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class AddressChronologyConverter
    {

        public static AddressChronologyDTO ToDto(this Bec.TargetFramework.Data.AddressChronology source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static AddressChronologyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.AddressChronology source, int level)
        {
            if (source == null)
              return null;

            var target = new AddressChronologyDTO();

            // Properties
            target.AddressChronologyID = source.AddressChronologyID;
            target.ParentID = source.ParentID;
            target.DataFrom = source.DataFrom;
            target.DateTo = source.DateTo;
            target.IsCurrentAddress = source.IsCurrentAddress;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Address = source.Address.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.AddressChronology ToEntity(this AddressChronologyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.AddressChronology();

            // Properties
            target.AddressChronologyID = source.AddressChronologyID;
            target.ParentID = source.ParentID;
            target.DataFrom = source.DataFrom;
            target.DateTo = source.DateTo;
            target.IsCurrentAddress = source.IsCurrentAddress;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<AddressChronologyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.AddressChronology> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<AddressChronologyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.AddressChronology> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.AddressChronology> ToEntities(this IEnumerable<AddressChronologyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.AddressChronology source, AddressChronologyDTO target);

        static partial void OnEntityCreating(AddressChronologyDTO source, Bec.TargetFramework.Data.AddressChronology target);

    }

}
