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

    public static partial class TransactionLevelComponentTemplateConverter
    {

        public static TransactionLevelComponentTemplateDTO ToDto(this Bec.TargetFramework.Data.TransactionLevelComponentTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TransactionLevelComponentTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.TransactionLevelComponentTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new TransactionLevelComponentTemplateDTO();

            // Properties
            target.TransactionLevelComponentTemplateID = source.TransactionLevelComponentTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsFixedFee = source.IsFixedFee;
            target.FixedFee = source.FixedFee;
            target.PercentageFee = source.PercentageFee;
            target.CountryID = source.CountryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.TransactionLevelComponentTypeID = source.TransactionLevelComponentTypeID;
            target.TransactionLevelComponentSubTypeID = source.TransactionLevelComponentSubTypeID;
            target.TransactionLevelComponentCategoryID = source.TransactionLevelComponentCategoryID;
            target.TransactionLevelComponentSubCategoryID = source.TransactionLevelComponentSubCategoryID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.TransactionLevelComponentTemplate ToEntity(this TransactionLevelComponentTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.TransactionLevelComponentTemplate();

            // Properties
            target.TransactionLevelComponentTemplateID = source.TransactionLevelComponentTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsFixedFee = source.IsFixedFee;
            target.FixedFee = source.FixedFee;
            target.PercentageFee = source.PercentageFee;
            target.CountryID = source.CountryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.TransactionLevelComponentTypeID = source.TransactionLevelComponentTypeID;
            target.TransactionLevelComponentSubTypeID = source.TransactionLevelComponentSubTypeID;
            target.TransactionLevelComponentCategoryID = source.TransactionLevelComponentCategoryID;
            target.TransactionLevelComponentSubCategoryID = source.TransactionLevelComponentSubCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TransactionLevelComponentTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.TransactionLevelComponentTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TransactionLevelComponentTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.TransactionLevelComponentTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.TransactionLevelComponentTemplate> ToEntities(this IEnumerable<TransactionLevelComponentTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.TransactionLevelComponentTemplate source, TransactionLevelComponentTemplateDTO target);

        static partial void OnEntityCreating(TransactionLevelComponentTemplateDTO source, Bec.TargetFramework.Data.TransactionLevelComponentTemplate target);

    }

}