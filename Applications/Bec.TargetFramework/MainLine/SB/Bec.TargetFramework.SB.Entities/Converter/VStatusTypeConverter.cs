﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 30/04/2015 14:40:27
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.SB.Entities
{

    public static partial class VStatusTypeConverter
    {

        public static VStatusTypeDTO ToDto(this Bec.TargetFramework.SB.Data.VStatusType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VStatusTypeDTO ToDtoWithRelated(this Bec.TargetFramework.SB.Data.VStatusType source, int level)
        {
            if (source == null)
              return null;

            var target = new VStatusTypeDTO();

            // Properties
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.Name = source.Name;
            target.StatusTypeName = source.StatusTypeName;
            target.StatusOrder = source.StatusOrder;
            target.IsStart = source.IsStart;
            target.IsEnd = source.IsEnd;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.SB.Data.VStatusType ToEntity(this VStatusTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.SB.Data.VStatusType();

            // Properties
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.Name = source.Name;
            target.StatusTypeName = source.StatusTypeName;
            target.StatusOrder = source.StatusOrder;
            target.IsStart = source.IsStart;
            target.IsEnd = source.IsEnd;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VStatusTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.SB.Data.VStatusType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VStatusTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.SB.Data.VStatusType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.SB.Data.VStatusType> ToEntities(this IEnumerable<VStatusTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.SB.Data.VStatusType source, VStatusTypeDTO target);

        static partial void OnEntityCreating(VStatusTypeDTO source, Bec.TargetFramework.SB.Data.VStatusType target);

    }

}
