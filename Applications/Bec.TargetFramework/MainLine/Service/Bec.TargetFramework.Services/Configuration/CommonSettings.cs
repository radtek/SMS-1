
using Bec.TargetFramework.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Services.Configuration
{
    public class CommonSettings : ISettings
    {
        public bool LogDatabaseTransactions { get; set; }
    }
}
