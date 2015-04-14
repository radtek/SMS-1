﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class StatusTypeStructureConverter
    {

        public static StatusTypeStructureDTO ToDto(this Bec.TargetFramework.Data.StatusTypeStructure source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeStructureDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StatusTypeStructure source, int level)
        {
            if (source == null)
              return null;

            var target = new StatusTypeStructureDTO();

            // Properties
            target.StatusTypeStructureID = source.StatusTypeStructureID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusOrder = source.StatusOrder;
            target.IsStart = source.IsStart;
            target.IsEnd = source.IsEnd;

            // Navigation Properties
            if (level > 0) {
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
              target.StatusTypeStructureTransitions_NextStatusTypeStructureID = source.StatusTypeStructureTransitions_NextStatusTypeStructureID.ToDtosWithRelated(level - 1);
              target.StatusTypeStructureTransitions_CurrentStatusTypeStructureID = source.StatusTypeStructureTransitions_CurrentStatusTypeStructureID.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StatusTypeStructure ToEntity(this StatusTypeStructureDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StatusTypeStructure();

            // Properties
            target.StatusTypeStructureID = source.StatusTypeStructureID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusOrder = source.StatusOrder;
            target.IsStart = source.IsStart;
            target.IsEnd = source.IsEnd;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StatusTypeStructureDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StatusTypeStructure> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeStructureDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StatusTypeStructure> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StatusTypeStructure> ToEntities(this IEnumerable<StatusTypeStructureDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StatusTypeStructure source, StatusTypeStructureDTO target);

        static partial void OnEntityCreating(StatusTypeStructureDTO source, Bec.TargetFramework.Data.StatusTypeStructure target);

    }

}
