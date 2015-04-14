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

    public static partial class ArtefactSubscriptionConverter
    {

        public static ArtefactSubscriptionDTO ToDto(this Bec.TargetFramework.Data.ArtefactSubscription source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactSubscriptionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactSubscription source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactSubscriptionDTO();

            // Properties
            target.ArtefactSubscriptionID = source.ArtefactSubscriptionID;
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Artefact = source.Artefact.ToDtoWithRelated(level - 1);
              target.PlanSubscription = source.PlanSubscription.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactSubscription ToEntity(this ArtefactSubscriptionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactSubscription();

            // Properties
            target.ArtefactSubscriptionID = source.ArtefactSubscriptionID;
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactSubscriptionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactSubscription> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactSubscriptionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactSubscription> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactSubscription> ToEntities(this IEnumerable<ArtefactSubscriptionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactSubscription source, ArtefactSubscriptionDTO target);

        static partial void OnEntityCreating(ArtefactSubscriptionDTO source, Bec.TargetFramework.Data.ArtefactSubscription target);

    }

}
