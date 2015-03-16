using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class LRServiceResponseDTO
    {
        public LRServiceResponseDTO()
        {
            ResponseDictionary = new ConcurrentDictionary<string, object>();
        }

        [DataMember]
        public Exception Exception { get; set; }
         [DataMember]
        public string ExceptionMessage { get; set; }

        public bool HasError
        {
            get { return (Exception != null); }
        }

        [DataMember]
        public ConcurrentDictionary<string, object> ResponseDictionary { get; set; }
         [DataMember]
        public LRServiceResponseStatusDTO ResponseStatus { get; set; }
    }
}
