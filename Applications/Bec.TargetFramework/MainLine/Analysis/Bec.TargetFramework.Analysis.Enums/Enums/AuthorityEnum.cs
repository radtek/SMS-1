using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Enums
{
    [System.Serializable]
    public enum AuthorityEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        NoData,

        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Probate,

        [System.Xml.Serialization.XmlEnumAttribute("2")]
        PowerOfAttorney,

        [System.Xml.Serialization.XmlEnumAttribute("3")]
        CourtProtectionOfficer,

        [System.Xml.Serialization.XmlEnumAttribute("4")]
        RegisteredProprietor,

        [System.Xml.Serialization.XmlEnumAttribute("5")]
        DeveloperOrBuilderPartExchangeScheme,

        [System.Xml.Serialization.XmlEnumAttribute("6")]
        ReceiverOrTrusteeInBankruptcyOrLiquidator,

        [System.Xml.Serialization.XmlEnumAttribute("7")]
        InstitutionalMortgagee,

        [System.Xml.Serialization.XmlEnumAttribute("8")]
        HousingAssociation,
    }
}
