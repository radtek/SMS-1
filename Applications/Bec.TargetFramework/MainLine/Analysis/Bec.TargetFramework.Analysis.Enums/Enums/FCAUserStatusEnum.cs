using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Enums
{
    [System.Serializable]
    public enum FCAUserStatusEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        NoData,

        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Active,

        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Inactive,

        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Banned,
    }
}
