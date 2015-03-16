using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Enums
{
    [System.Serializable]
    public enum PartyTypeEnum
    {
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        NoData,

        BCCO,
        BCFO,
        BCBA,
        BCU,
        BUY,
        GIFT,
        SCCO,
        SCFO,
        SCBA,
        SCU,
        SELL,
        MBSIF,
        MBU,
        TPI,
        EACO,
        EAU,
        VSUR,
        BSUR,
        LEAD,
        LEREP,
        SAD,
        SU,
        MLRO,
    }
}
