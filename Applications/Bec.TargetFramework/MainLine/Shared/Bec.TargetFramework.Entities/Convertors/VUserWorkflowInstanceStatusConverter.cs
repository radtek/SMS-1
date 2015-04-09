﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VUserWorkflowInstanceStatusConverter
    {

        public static VUserWorkflowInstanceStatusDTO ToDto(this Bec.TargetFramework.Data.VUserWorkflowInstanceStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VUserWorkflowInstanceStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VUserWorkflowInstanceStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new VUserWorkflowInstanceStatusDTO();

            // Properties
            target.ParentID = source.ParentID;
            target.UserID = source.UserID;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowInstanceStatusID = source.WorkflowInstanceStatusID;
            target.Instancestatus = source.Instancestatus;
            target.Workflowtype = source.Workflowtype;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VUserWorkflowInstanceStatus ToEntity(this VUserWorkflowInstanceStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VUserWorkflowInstanceStatus();

            // Properties
            target.ParentID = source.ParentID;
            target.UserID = source.UserID;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowInstanceStatusID = source.WorkflowInstanceStatusID;
            target.Instancestatus = source.Instancestatus;
            target.Workflowtype = source.Workflowtype;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VUserWorkflowInstanceStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VUserWorkflowInstanceStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VUserWorkflowInstanceStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VUserWorkflowInstanceStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VUserWorkflowInstanceStatus> ToEntities(this IEnumerable<VUserWorkflowInstanceStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VUserWorkflowInstanceStatus source, VUserWorkflowInstanceStatusDTO target);

        static partial void OnEntityCreating(VUserWorkflowInstanceStatusDTO source, Bec.TargetFramework.Data.VUserWorkflowInstanceStatus target);

    }

}
