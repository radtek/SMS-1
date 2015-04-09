﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class StatusTypeStructureTransitionConverter
    {

        public static StatusTypeStructureTransitionDTO ToDto(this Bec.TargetFramework.Data.StatusTypeStructureTransition source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeStructureTransitionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StatusTypeStructureTransition source, int level)
        {
            if (source == null)
              return null;

            var target = new StatusTypeStructureTransitionDTO();

            // Properties
            target.StatusTypeStructureTransitionID = source.StatusTypeStructureTransitionID;
            target.CurrentStatusTypeStructureID = source.CurrentStatusTypeStructureID;
            target.NextStatusTypeStructureID = source.NextStatusTypeStructureID;

            // Navigation Properties
            if (level > 0) {
              target.StatusTypeStructure_NextStatusTypeStructureID = source.StatusTypeStructure_NextStatusTypeStructureID.ToDtoWithRelated(level - 1);
              target.StatusTypeStructure_CurrentStatusTypeStructureID = source.StatusTypeStructure_CurrentStatusTypeStructureID.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StatusTypeStructureTransition ToEntity(this StatusTypeStructureTransitionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StatusTypeStructureTransition();

            // Properties
            target.StatusTypeStructureTransitionID = source.StatusTypeStructureTransitionID;
            target.CurrentStatusTypeStructureID = source.CurrentStatusTypeStructureID;
            target.NextStatusTypeStructureID = source.NextStatusTypeStructureID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StatusTypeStructureTransitionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StatusTypeStructureTransition> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeStructureTransitionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StatusTypeStructureTransition> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StatusTypeStructureTransition> ToEntities(this IEnumerable<StatusTypeStructureTransitionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StatusTypeStructureTransition source, StatusTypeStructureTransitionDTO target);

        static partial void OnEntityCreating(StatusTypeStructureTransitionDTO source, Bec.TargetFramework.Data.StatusTypeStructureTransition target);

    }

}
