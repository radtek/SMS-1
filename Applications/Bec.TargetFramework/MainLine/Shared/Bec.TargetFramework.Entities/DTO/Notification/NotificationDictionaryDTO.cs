using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Fabrik.Common;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    [KnownType("GetDerivedTypes")]
    public class NotificationDictionaryDTO
    {
        public NotificationDictionaryDTO()
        {
            NotificationDictionary = new ConcurrentDictionary<string, object>();

        }

        [DataMember]
        public ConcurrentDictionary<string, object> NotificationDictionary { get; set; }

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
