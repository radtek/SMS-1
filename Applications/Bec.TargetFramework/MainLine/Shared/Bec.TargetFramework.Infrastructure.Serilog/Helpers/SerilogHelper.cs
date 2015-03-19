using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using LogNs = Serilog;

namespace Bec.TargetFramework.Infrastructure.Serilog.Helpers
{
    public class SerilogHelper
    {
        public static void LogException(string applicationName,Exception ex)
        {

            if (LogNs.Log.Logger == null)
                    new SerilogLogger(true, false, applicationName).Error(ex);
                else
                    LogNs.Log.Logger.Error(ex, ex.Message, null);
        }
    }
}
