using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Fabrik.Common;
using Bec.TargetFramework.Entities.DTO.Workflow;
namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    [KnownType("GetDerivedTypes")]
    public class WorkflowStateBaseDTO
    {
        public WorkflowStateBaseDTO()
        {
            WorkflowDictionaryDto = new WorkflowDictionaryDTO();
        }

        [DataMember]
        public WorkflowDictionaryDTO WorkflowDictionaryDto { get;set;}
        [DataMember]
        public Guid CurrentWorkflowComponentID { get;set;}

        [DataMember]
        public List<KeyValuePair<Guid,Guid>> Queue { get;set;}
        [DataMember]
        public Guid? PreviousCurrentWorkflowComponentID { get; set; }
        [DataMember]
        public Guid? TransistionID { get; set; }

        public static IEnumerable<Type> GetDerivedTypes()
        {
            List<Type> derivedTypes = new List<Type>();

            AppDomain.CurrentDomain.GetAssemblies().Where(it => it.FullName.StartsWith("Bec.TargetFramework.Ent"))
                .SelectMany(s => s.GetTypes())
                .Where(s => s.GetCustomAttributes(typeof(DataContractAttribute), true).Any())
                .ForEach(ass => derivedTypes.Add(ass));

            return derivedTypes.ToArray();
        }

        [DataMember]
        public Guid? InstanceID { get; set; }
    }
}
