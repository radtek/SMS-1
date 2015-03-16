using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Enums
{
    [System.Serializable]
    public enum TitleGradeEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        NoData,

        [System.Xml.Serialization.XmlEnumAttribute("1")]
        AbsoluteFreehold,

        [System.Xml.Serialization.XmlEnumAttribute("2")]
        PossessoryFreehold,

        [System.Xml.Serialization.XmlEnumAttribute("3")]
        QualifiedFreehold,

        [System.Xml.Serialization.XmlEnumAttribute("4")]
        SchemeTitleFreehold,

        [System.Xml.Serialization.XmlEnumAttribute("5")]
        SchemeTitleLeasehold,

        [System.Xml.Serialization.XmlEnumAttribute("6")]
        AbsoluteLeasehold,

        [System.Xml.Serialization.XmlEnumAttribute("7")]
        GoodLeasehold,

        [System.Xml.Serialization.XmlEnumAttribute("8")]
        QualifiedLeasehold,

        [System.Xml.Serialization.XmlEnumAttribute("9")]
        PossessoryLeasehold,

        [System.Xml.Serialization.XmlEnumAttribute("10")]
        AbsoluteRentcharge,

        [System.Xml.Serialization.XmlEnumAttribute("11")]
        PossessoryRentcharge,

        [System.Xml.Serialization.XmlEnumAttribute("12")]
        QualifiedRentcharge,

        [System.Xml.Serialization.XmlEnumAttribute("13")]
        CautionAgainstFirstRegistration,
    }
}
