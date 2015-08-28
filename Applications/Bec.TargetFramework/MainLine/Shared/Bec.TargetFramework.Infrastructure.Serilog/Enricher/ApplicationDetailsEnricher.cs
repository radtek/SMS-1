using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Serilog.Core;
using Serilog.Events;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ApplicationDetailsEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            try
            {
                if (Assembly.GetEntryAssembly() != null)
                {
                    var applicationAssembly = Assembly.GetEntryAssembly();
                    var name = applicationAssembly.GetName().Name;
                    var version = applicationAssembly.GetName().Version;

                    logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ApplicationName", name));
                    logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ApplicationVersion", version));
                }
              
            }
            catch (Exception)
            {
                // TBD no need to log this
            }
           
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MachineName", System.Environment.MachineName));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MachineUserDomain", System.Environment.UserDomainName));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MachineUserName", System.Environment.UserName));
        }
    }
}
