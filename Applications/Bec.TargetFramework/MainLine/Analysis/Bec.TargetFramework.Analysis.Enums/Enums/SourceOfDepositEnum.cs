using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Enums
{
    [System.Serializable]
    public enum SourceOfDepositEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        NoData,

        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Gifted,

        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Secured,

        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Loan,

        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Savings,

        [System.Xml.Serialization.XmlEnumAttribute("5")]
        EquityFromSale,
    }
}
