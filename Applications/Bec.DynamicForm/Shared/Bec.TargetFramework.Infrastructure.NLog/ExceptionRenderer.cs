using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Bec.TargetFramework.Infrastructure.NLog
{
    [ThreadAgnostic]
    [LayoutRenderer(Name)]
    public sealed class ExceptionDetailsRenderer : LayoutRenderer
    {
        public const string Name = "exceptiondetails";
        private const string _Spacer = "======================================";
        private List<string> _FilteredProperties;

        private List<string> FilteredProperties
        {
            get
            {
                if (_FilteredProperties == null)
                {
                    _FilteredProperties = new List<string>
                    {
                        "StackTrace",
                        "HResult",
                        "InnerException",
                        "Data"
                    };
                }

                return _FilteredProperties;
            }
        }

        public bool LogNulls { get; set; }

        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            Append(builder, logEvent.Exception, false);
        }

        private void Append(StringBuilder builder, Exception exception, bool isInnerException)
        {
            if (exception == null)
            {
                return;
            }

            builder.AppendLine();

            var type = exception.GetType();
            if (isInnerException)
            {
                builder.Append("Inner ");
            }

            builder.AppendLine("Exception Details:")
                .AppendLine(_Spacer)
                .Append("Exception Type: ")
                .AppendLine(type.ToString());

            var bindingFlags = BindingFlags.Instance
                | BindingFlags.Public;
            var properties = type.GetProperties(bindingFlags);
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var isFiltered = FilteredProperties.Any(filter => String.Equals(propertyName, filter, StringComparison.InvariantCultureIgnoreCase));
                if (isFiltered)
                {
                    continue;
                }

                var propertyValue = property.GetValue(exception, bindingFlags, null, null, null);
                if (propertyValue == null && !LogNulls)
                {
                    continue;
                }

                var valueText = propertyValue != null ? propertyValue.ToString() : "NULL";
                builder.Append(propertyName)
                    .Append(": ")
                    .AppendLine(valueText);
            }

            AppendStackTrace(builder, exception.StackTrace, isInnerException);
            Append(builder, exception.InnerException, true);
        }

        private void AppendStackTrace(StringBuilder builder, string stackTrace, bool isInnerException)
        {
            if (String.IsNullOrEmpty(stackTrace))
            {
                return;
            }

            builder.AppendLine();

            if (isInnerException)
            {
                builder.Append("Inner ");
            }

            builder.AppendLine("Exception StackTrace:")
                .AppendLine(_Spacer)
                .AppendLine(stackTrace);
        }

        public static void Register()
        {
            Type definitionType;
            var layoutRenderers = ConfigurationItemFactory.Default.LayoutRenderers;
            if (layoutRenderers.TryGetDefinition(Name, out definitionType))
            {
                return;
            }

            layoutRenderers.RegisterDefinition(Name, typeof(ExceptionDetailsRenderer));
            LogManager.ReconfigExistingLoggers();
        }
    }
}
