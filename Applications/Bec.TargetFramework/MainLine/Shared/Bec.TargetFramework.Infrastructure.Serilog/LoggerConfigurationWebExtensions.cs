using System;
using System.Web;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Formatting.Display;

namespace Bec.TargetFramework.Infrastructure.Serilog
{
    public static class LoggerConfigurationWebExtensions
    {
        const string DefaultOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message:l}{NewLine:l}{Exception:l}";

        public static LoggerConfiguration TraceContext(
            this LoggerSinkConfiguration sinkConfiguration,
            Func<HttpContextBase> httpContextGetter = null,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
            string outputTemplate = DefaultOutputTemplate,
            IFormatProvider formatProvider = null)
        {
            if (sinkConfiguration == null) throw new ArgumentNullException("sinkConfiguration");
            if (outputTemplate == null) throw new ArgumentNullException("outputTemplate");

            if (httpContextGetter == null)
            {
                httpContextGetter = Utilities.GetCurrentHttpContext;
            }

            var formatter = new MessageTemplateTextFormatter(outputTemplate, formatProvider);
            return sinkConfiguration.Sink(new TraceContextSink(formatter, httpContextGetter), restrictedToMinimumLevel);
        }
    }
}