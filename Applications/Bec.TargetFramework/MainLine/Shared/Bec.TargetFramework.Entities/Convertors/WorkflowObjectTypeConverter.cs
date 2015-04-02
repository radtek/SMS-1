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

    public static partial class WorkflowObjectTypeConverter
    {

        public static WorkflowObjectTypeDTO ToDto(this Bec.TargetFramework.Data.WorkflowObjectType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowObjectTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowObjectType source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowObjectTypeDTO();

            // Properties
            target.WorkflowObjectTypeID = source.WorkflowObjectTypeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ObjectTypeName = source.ObjectTypeName;
            target.ObjectTypeNameSpace = source.ObjectTypeNameSpace;
            target.ObjectTypeAssembly = source.ObjectTypeAssembly;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowActions = source.WorkflowActions.ToDtosWithRelated(level - 1);
              target.WorkflowDecisions = source.WorkflowDecisions.ToDtosWithRelated(level - 1);
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowCommands = source.WorkflowCommands.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowObjectType ToEntity(this WorkflowObjectTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowObjectType();

            // Properties
            target.WorkflowObjectTypeID = source.WorkflowObjectTypeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ObjectTypeName = source.ObjectTypeName;
            target.ObjectTypeNameSpace = source.ObjectTypeNameSpace;
            target.ObjectTypeAssembly = source.ObjectTypeAssembly;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowObjectTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowObjectType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowObjectTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowObjectType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowObjectType> ToEntities(this IEnumerable<WorkflowObjectTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowObjectType source, WorkflowObjectTypeDTO target);

        static partial void OnEntityCreating(WorkflowObjectTypeDTO source, Bec.TargetFramework.Data.WorkflowObjectType target);

    }

}
