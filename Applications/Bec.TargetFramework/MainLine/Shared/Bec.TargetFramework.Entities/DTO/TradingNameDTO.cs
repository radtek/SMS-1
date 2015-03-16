using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(List<TradingNameDTO>))] 
    public class TradingNameDTO
    {
        [DataMember]
        public string TradingName { get; set; }

        [DataMember]
        public string ID { get; set; }
    }
}
