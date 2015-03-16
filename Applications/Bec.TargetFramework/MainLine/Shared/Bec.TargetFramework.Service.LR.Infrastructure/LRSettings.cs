using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Framework.Configuration;

namespace Bec.TargetFramework.Service.LR.Infrastructure
{
    public class LRSettings : ISettings
    {
        public string LRUserName { get; set; }
        public string LRPassword { get; set; }

        public string LRCertificatSerialNumber { get; set; }

        public string LRBindingConfigurationName { get; set; }

        public string Environment { get; set; }

    }
}
