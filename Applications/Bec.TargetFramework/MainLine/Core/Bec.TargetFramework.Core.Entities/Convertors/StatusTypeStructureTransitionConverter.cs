﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:00:41
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Core.Entities
{

    public static partial class StatusTypeStructureTransitionConverter
    {

        public static StatusTypeStructureTransitionDTO ToDto(this TargetFrameworkCoreModel.StatusTypeStructureTransition source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeStructureTransitionDTO ToDtoWithRelated(this TargetFrameworkCoreModel.StatusTypeStructureTransition source, int level)
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
              target.StatusTypeStructure_CurrentStatusTypeStructureID = source.StatusTypeStructure_CurrentStatusTypeStructureID.ToDtoWithRelated(level - 1);
              target.StatusTypeStructure_NextStatusTypeStructureID = source.StatusTypeStructure_NextStatusTypeStructureID.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static TargetFrameworkCoreModel.StatusTypeStructureTransition ToEntity(this StatusTypeStructureTransitionDTO source)
        {
            if (source == null)
              return null;

            var target = new TargetFrameworkCoreModel.StatusTypeStructureTransition();

            // Properties
            target.StatusTypeStructureTransitionID = source.StatusTypeStructureTransitionID;
            target.CurrentStatusTypeStructureID = source.CurrentStatusTypeStructureID;
            target.NextStatusTypeStructureID = source.NextStatusTypeStructureID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StatusTypeStructureTransitionDTO> ToDtos(this IEnumerable<TargetFrameworkCoreModel.StatusTypeStructureTransition> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeStructureTransitionDTO> ToDtosWithRelated(this IEnumerable<TargetFrameworkCoreModel.StatusTypeStructureTransition> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<TargetFrameworkCoreModel.StatusTypeStructureTransition> ToEntities(this IEnumerable<StatusTypeStructureTransitionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(TargetFrameworkCoreModel.StatusTypeStructureTransition source, StatusTypeStructureTransitionDTO target);

        static partial void OnEntityCreating(StatusTypeStructureTransitionDTO source, TargetFrameworkCoreModel.StatusTypeStructureTransition target);

    }

}
