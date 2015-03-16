using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Enums
{
    [System.Serializable]
    public enum StatusEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        NoData,

        [System.Xml.Serialization.XmlEnumAttribute("1")]
        UnderOffer,

        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Exchanged,

        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Completed,

        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Registered,

        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Archived,

        [System.Xml.Serialization.XmlEnumAttribute("6")]
        Cancelled,
    }
}
