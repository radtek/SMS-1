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

    public static partial class WorkflowTreeStructureTemplateConverter
    {

        public static WorkflowTreeStructureTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowTreeStructureTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTreeStructureTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTreeStructureTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTreeStructureTemplateDTO();

            // Properties
            target.WorkflowTreeStructureTemplateID = source.WorkflowTreeStructureTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Level = source.Level;
            target.IsLeafNode = source.IsLeafNode;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.ItemOrder = source.ItemOrder;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanelTemplate = source.InterfacePanelTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTreeStructureTemplate ToEntity(this WorkflowTreeStructureTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTreeStructureTemplate();

            // Properties
            target.WorkflowTreeStructureTemplateID = source.WorkflowTreeStructureTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Level = source.Level;
            target.IsLeafNode = source.IsLeafNode;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.ItemOrder = source.ItemOrder;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTreeStructureTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTreeStructureTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTreeStructureTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTreeStructureTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTreeStructureTemplate> ToEntities(this IEnumerable<WorkflowTreeStructureTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTreeStructureTemplate source, WorkflowTreeStructureTemplateDTO target);

        static partial void OnEntityCreating(WorkflowTreeStructureTemplateDTO source, Bec.TargetFramework.Data.WorkflowTreeStructureTemplate target);

    }

}
