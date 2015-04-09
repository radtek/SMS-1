﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VWorkflowInstanceProgressConverter
    {

        public static VWorkflowInstanceProgressDTO ToDto(this Bec.TargetFramework.Data.VWorkflowInstanceProgress source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VWorkflowInstanceProgressDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VWorkflowInstanceProgress source, int level)
        {
            if (source == null)
              return null;

            var target = new VWorkflowInstanceProgressDTO();

            // Properties
            target.StepName = source.StepName;
            target.StepID = source.StepID;
            target.StepStatus = source.StepStatus;
            target.StepDate = source.StepDate;
            target.StepExecutedBy = source.StepExecutedBy;
            target.StepOrder = source.StepOrder;
            target.StepType = source.StepType;
            target.StepIsManual = source.StepIsManual;
            target.StepIsStart = source.StepIsStart;
            target.StepIsEnd = source.StepIsEnd;
            target.TransistionName = source.TransistionName;
            target.IsWorkflowStart = source.IsWorkflowStart;
            target.IsWorkflowEnd = source.IsWorkflowEnd;
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowInstanceExecutionStatusEventID = source.WorkflowInstanceExecutionStatusEventID;
            target.WorkflowExecutionStatusID = source.WorkflowExecutionStatusID;
            target.WorkflowInstanceExecutionID = source.WorkflowInstanceExecutionID;
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.Actionarea = source.Actionarea;
            target.Actionaction = source.Actionaction;
            target.Actioncontroller = source.Actioncontroller;
            target.WorkflowTypeID = source.WorkflowTypeID;
            target.Workflowtypename = source.Workflowtypename;
            target.WorkflowCategoryID = source.WorkflowCategoryID;
            target.Workflowcategoryname = source.Workflowcategoryname;
            target.WorkflowInstanceStatusID = source.WorkflowInstanceStatusID;
            target.Workflowinstancestatusname = source.Workflowinstancestatusname;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VWorkflowInstanceProgress ToEntity(this VWorkflowInstanceProgressDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VWorkflowInstanceProgress();

            // Properties
            target.StepName = source.StepName;
            target.StepID = source.StepID;
            target.StepStatus = source.StepStatus;
            target.StepDate = source.StepDate;
            target.StepExecutedBy = source.StepExecutedBy;
            target.StepOrder = source.StepOrder;
            target.StepType = source.StepType;
            target.StepIsManual = source.StepIsManual;
            target.StepIsStart = source.StepIsStart;
            target.StepIsEnd = source.StepIsEnd;
            target.TransistionName = source.TransistionName;
            target.IsWorkflowStart = source.IsWorkflowStart;
            target.IsWorkflowEnd = source.IsWorkflowEnd;
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowInstanceExecutionStatusEventID = source.WorkflowInstanceExecutionStatusEventID;
            target.WorkflowExecutionStatusID = source.WorkflowExecutionStatusID;
            target.WorkflowInstanceExecutionID = source.WorkflowInstanceExecutionID;
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.Actionarea = source.Actionarea;
            target.Actionaction = source.Actionaction;
            target.Actioncontroller = source.Actioncontroller;
            target.WorkflowTypeID = source.WorkflowTypeID;
            target.Workflowtypename = source.Workflowtypename;
            target.WorkflowCategoryID = source.WorkflowCategoryID;
            target.Workflowcategoryname = source.Workflowcategoryname;
            target.WorkflowInstanceStatusID = source.WorkflowInstanceStatusID;
            target.Workflowinstancestatusname = source.Workflowinstancestatusname;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VWorkflowInstanceProgressDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VWorkflowInstanceProgress> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VWorkflowInstanceProgressDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VWorkflowInstanceProgress> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VWorkflowInstanceProgress> ToEntities(this IEnumerable<VWorkflowInstanceProgressDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VWorkflowInstanceProgress source, VWorkflowInstanceProgressDTO target);

        static partial void OnEntityCreating(VWorkflowInstanceProgressDTO source, Bec.TargetFramework.Data.VWorkflowInstanceProgress target);

    }

}
