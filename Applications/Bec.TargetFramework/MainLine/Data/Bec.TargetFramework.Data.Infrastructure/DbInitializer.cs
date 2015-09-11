using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Infrastructure
{
    //public class DbInitializer
    //{
    //    public static void Initialize(IContainer autoFacContainer)
    //    {
    //        var settings = autoFacContainer.Resolve<CommonSettings>();

    //        // add interceptor
    //        if (settings != null)
    //            DbInterception.Add(new LoggerCommandInterceptor(new SerilogLogger(true,false,"Database"), settings.LogTraceDatabase, settings.LogDebugDatabase));
    //    }
    //}
}
