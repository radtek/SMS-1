using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Fabrik.Common;

namespace Bec.TargetFramework.Entities.DTO.Workflow
{
    [DataContract]
    [Serializable]
    [KnownType("GetDerivedTypes")]
    public class WorkflowDictionaryDTO
    {
        public WorkflowDictionaryDTO()
        {
            WorkflowDictionary = new ConcurrentDictionary<string, object>();

        }

        [DataMember]
        public ConcurrentDictionary<string, object> WorkflowDictionary { get; set; }

        public static IEnumerable<Type> GetDerivedTypes()
        {
            List<Type> derivedTypes = new List<Type>();

            AppDomain.CurrentDomain.GetAssemblies().Where(it => it.FullName.StartsWith("Bec.TargetFramework.Ent"))
                .SelectMany(s => s.GetTypes())
                .Where(s => s.GetCustomAttributes(typeof(DataContractAttribute),true).Any())
                .ForEach(ass => derivedTypes.Add(ass));

            return derivedTypes.ToArray();
        }
    }
}
