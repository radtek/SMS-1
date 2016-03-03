using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class DTOMap : Dictionary<string, DTOMapItem>
    {
        public NotificationDictionaryDTO ToNotificationDictionaryDTO()
        {
            var dictionary = new ConcurrentDictionary<string, object>();
            foreach (var item in this) dictionary.TryAdd(item.Key, item.Value.ToDTO());            
            return new NotificationDictionaryDTO { NotificationDictionary = dictionary };
        }

        public void Add(string key, object o)
        {
            base.Add(key, new DTOMapItem(o));
        }
    }

    [Serializable]
    public class DTOMapItem
    {
        public DTOMapItem(object obj)
        {
            Data = obj;
            Type = obj.GetType().FullName;
        }

        public string Type { get; set; }
        public object Data { get; set; }

        public object ToDTO()
        {
            JObject val = Data as JObject;
            return val.ToObject(System.Type.GetType(Type));
        }
    }
}
