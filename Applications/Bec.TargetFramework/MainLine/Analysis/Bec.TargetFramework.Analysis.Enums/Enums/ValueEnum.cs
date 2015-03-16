using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Enums
{
    [System.Serializable]
    public enum ValueEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        NoData,

        [System.Xml.Serialization.XmlEnumAttribute("1")]
        TrueMatchClear,

        [System.Xml.Serialization.XmlEnumAttribute("2")]
        FalseNoMatch,

        [System.Xml.Serialization.XmlEnumAttribute("3")]
        PartialMatch,

        [System.Xml.Serialization.XmlEnumAttribute("4")]
        CautionRefer,
    }
}
