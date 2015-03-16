using System;
using System.Net;
using System.Net.Sockets;
using Serilog.Debugging;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Environment
{
    public class HostNameEnricher : NamedScalarEnricherBase
    {
        public HostNameEnricher(string propertyName) : base(propertyName)
        {
            // Host name cannot be changed without reboot???
            _hostName = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _hostName;
        }

        internal static string GetValue()
        {
            string value;
            try
            {
                value = Dns.GetHostName();
            }
            catch (SocketException e)
            {
                SelfLog.WriteLine(String.Format("{0} failed calling Dns.GetHostName() because of socket error {1}",
                    typeof(HostNameEnricher).Name, e.Message));
                value = System.Environment.MachineName;
            }
            return value;
        }

        private readonly string _hostName;
    }
}