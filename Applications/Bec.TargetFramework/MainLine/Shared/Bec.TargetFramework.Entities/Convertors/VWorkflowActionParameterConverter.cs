﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VWorkflowActionParameterConverter
    {

        public static VWorkflowActionParameterDTO ToDto(this Bec.TargetFramework.Data.VWorkflowActionParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VWorkflowActionParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VWorkflowActionParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new VWorkflowActionParameterDTO();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ObjectType = source.ObjectType;
            target.ObjectValue = source.ObjectValue;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VWorkflowActionParameter ToEntity(this VWorkflowActionParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VWorkflowActionParameter();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ObjectType = source.ObjectType;
            target.ObjectValue = source.ObjectValue;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VWorkflowActionParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VWorkflowActionParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VWorkflowActionParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VWorkflowActionParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VWorkflowActionParameter> ToEntities(this IEnumerable<VWorkflowActionParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VWorkflowActionParameter source, VWorkflowActionParameterDTO target);

        static partial void OnEntityCreating(VWorkflowActionParameterDTO source, Bec.TargetFramework.Data.VWorkflowActionParameter target);

    }

}
