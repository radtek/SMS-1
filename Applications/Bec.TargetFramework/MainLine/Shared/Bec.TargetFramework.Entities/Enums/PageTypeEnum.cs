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
        Tour = 800000,
        [StringValue("Callout")]
        Callout = 800001,
        [StringValue("Show Me How")]
        ShowMeHow = 800002
    }
}
