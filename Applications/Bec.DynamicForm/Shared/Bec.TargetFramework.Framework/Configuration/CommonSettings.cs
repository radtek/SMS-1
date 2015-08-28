
using Bec.TargetFramework.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Framework.Configuration
{
    public class CommonSettings : ISettings
    {
        public bool LogDebugDatabase { get; set; }
        public bool LogTraceDatabase { get; set; }
    }
}
