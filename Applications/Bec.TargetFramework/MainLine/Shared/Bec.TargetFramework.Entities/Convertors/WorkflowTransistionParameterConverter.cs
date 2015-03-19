﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowTransistionParameterConverter
    {

        public static WorkflowTransistionParameterDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionParameterDTO();

            // Properties
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowParameter = source.WorkflowParameter.ToDtoWithRelated(level - 1);
              target.WorkflowTransistion = source.WorkflowTransistion.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionParameter ToEntity(this WorkflowTransistionParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionParameter();

            // Properties
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionParameter> ToEntities(this IEnumerable<WorkflowTransistionParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionParameter source, WorkflowTransistionParameterDTO target);

        static partial void OnEntityCreating(WorkflowTransistionParameterDTO source, Bec.TargetFramework.Data.WorkflowTransistionParameter target);

    }

}
