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

    public static partial class GlobalDirectDebitCollectionPeriodConverter
    {

        public static GlobalDirectDebitCollectionPeriodDTO ToDto(this Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static GlobalDirectDebitCollectionPeriodDTO ToDtoWithRelated(this Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod source, int level)
        {
            if (source == null)
              return null;

            var target = new GlobalDirectDebitCollectionPeriodDTO();

            // Properties
            target.GlobalDirectDebitCollectionPeriodID = source.GlobalDirectDebitCollectionPeriodID;
            target.PeriodNumber = source.PeriodNumber;
            target.CollectionDay = source.CollectionDay;
            target.CollectionMonth = source.CollectionMonth;
            target.CollectionYear = source.CollectionYear;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsCurrentPeriod = source.IsCurrentPeriod;
            target.IsManuallyDrivenOnly = source.IsManuallyDrivenOnly;
            target.IsClosed = source.IsClosed;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod ToEntity(this GlobalDirectDebitCollectionPeriodDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod();

            // Properties
            target.GlobalDirectDebitCollectionPeriodID = source.GlobalDirectDebitCollectionPeriodID;
            target.PeriodNumber = source.PeriodNumber;
            target.CollectionDay = source.CollectionDay;
            target.CollectionMonth = source.CollectionMonth;
            target.CollectionYear = source.CollectionYear;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsCurrentPeriod = source.IsCurrentPeriod;
            target.IsManuallyDrivenOnly = source.IsManuallyDrivenOnly;
            target.IsClosed = source.IsClosed;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<GlobalDirectDebitCollectionPeriodDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<GlobalDirectDebitCollectionPeriodDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod> ToEntities(this IEnumerable<GlobalDirectDebitCollectionPeriodDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod source, GlobalDirectDebitCollectionPeriodDTO target);

        static partial void OnEntityCreating(GlobalDirectDebitCollectionPeriodDTO source, Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod target);

    }

}
