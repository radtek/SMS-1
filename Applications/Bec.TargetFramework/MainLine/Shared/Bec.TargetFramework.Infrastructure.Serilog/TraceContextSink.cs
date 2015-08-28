using System;
using System.IO;
using System.Web;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;

namespace Bec.TargetFramework.Infrastructure.Serilog
{
    public class TraceContextSink : ILogEventSink
    {
        public TraceContextSink(ITextFormatter textFormatter, Func<HttpContextBase> httpContextGetter = null)
        {
            if (textFormatter == null) throw new ArgumentNullException("textFormatter");

            _textFormatter = textFormatter;
            _httpContextGetter = httpContextGetter ?? Utilities.GetCurrentHttpContext;
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException("logEvent");

            var httpContext = _httpContextGetter();
            if (httpContext != null)
            {
                var traceContext = httpContext.Trace;
                if ((traceContext != null) && traceContext.IsEnabled)
                {
                    var sr = new StringWriter();
                    _textFormatter.Format(logEvent, sr);
                    traceContext.Write(logEvent.Level.ToString("G"), sr.ToString(), logEvent.Exception);
                }
            }
        }

        private readonly ITextFormatter _textFormatter;
        private readonly Func<HttpContextBase> _httpContextGetter;
    }
}