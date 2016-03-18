using Bec.TargetFramework.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum HelpTypeEnum
    {
        All = 1,
        Tour = 918291721,
        Callout = 918291722,
        [StringValue("Show Me How")]
        ShowMeHow = 918291723
    }

    public enum HelpPositionEnum
    {
        Top = 1278381271,
        Bottom = 1278381272,
        Left = 1278381273,
        Right = 1278381274
    }
}
