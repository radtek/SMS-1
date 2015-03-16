using System.Data.Entity.Core.Objects.DataClasses;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bec.TargetFramework.Workflow.Helpers
{
    using Bec.TargetFramework.Entities;
    using System.Runtime.Serialization.Formatters;

    public class WorkflowDataHelper
    {
        public static WorkflowStateBaseDTO DeserializeData(string content)
        {
            var obj = JsonConvert.DeserializeObject<WorkflowStateBaseDTO>(content, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });




            return obj;

            //JsonConvert.SerializeObject(EntityObject, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            //return JsonSerializer.DeserializeFromString<WorkflowStateBaseDTO>(content);
        }

        public static string SerializeData(WorkflowStateBaseDTO content)
        {
            var obj = JsonConvert.SerializeObject(content, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });


            return obj;
        }

        public static WorkflowStateBaseDTO CreateWorkflowState(IWorkflowComponent component, List<IWorkflowMainComponent> queue, Guid transistionID,ConcurrentDictionary<string,object> data = null )
        {
            if(component.Data != null)
                return new WorkflowStateBaseDTO{ CurrentWorkflowComponentID = component.ID, TransistionID = transistionID, PreviousCurrentWorkflowComponentID = component.PreviousComponentID,WorkflowDictionaryDto = new WorkflowDictionaryDTO{WorkflowDictionary = component.Data}, Queue = queue.Select(s => new KeyValuePair<Guid, Guid>(s.ID, s.PreviousComponentID.Value)).ToList() };
            else
                return new WorkflowStateBaseDTO { CurrentWorkflowComponentID = component.ID, TransistionID = transistionID, PreviousCurrentWorkflowComponentID = component.PreviousComponentID, WorkflowDictionaryDto = new WorkflowDictionaryDTO { WorkflowDictionary = data }, Queue = queue.Select(s => new KeyValuePair<Guid, Guid>(s.ID, s.PreviousComponentID.Value)).ToList() };
        }
    }
}
