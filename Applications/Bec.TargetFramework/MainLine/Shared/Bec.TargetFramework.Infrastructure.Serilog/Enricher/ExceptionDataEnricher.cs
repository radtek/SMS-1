using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Core;
using Serilog.Events;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ExceptionDataEnricher : ILogEventEnricher 
    {
       public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Exception == null ||
                logEvent.Exception.Data == null ||
                logEvent.Exception.Data.Count == 0) return;
 
            var dataDictionary = logEvent.Exception.Data
                .Cast<DictionaryEntry>()
                .Where(e => e.Key is string)
                .ToDictionary(e => (string)e.Key, e => e.Value);
 
            var property = propertyFactory.CreateProperty("ExceptionData", dataDictionary, destructureObjects: true);
 
            logEvent.AddPropertyIfAbsent(property);
        }
    }

}
