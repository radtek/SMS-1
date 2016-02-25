using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum PageType : int
    {
        [StringValue("Tour")]
        Tour = 1,
        [StringValue("Show Me How")]
        ShowMeHow = 2,
        [StringValue("Callout")]
        Callout = 3
    }
}
