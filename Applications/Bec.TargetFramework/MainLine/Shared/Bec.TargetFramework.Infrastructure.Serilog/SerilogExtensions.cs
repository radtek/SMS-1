using Serilog;
using Serilog.Events;

namespace Bec.TargetFramework.Infrastructure.Serilog
{
    public static class SerilogExtensions
    {
         public static bool IsVerboseEnabled(this ILogger logger)
         {
             return logger.IsEnabled(LogEventLevel.Verbose);
         }

         public static bool IsDebugEnabled(this ILogger logger)
         {
             return logger.IsEnabled(LogEventLevel.Debug);
         }

         public static bool IsInfoEnabled(this ILogger logger)
         {
             return logger.IsEnabled(LogEventLevel.Information);
         }

         public static bool IsInformationEnabled(this ILogger logger)
         {
             return logger.IsEnabled(LogEventLevel.Information);
         }

         public static bool IsWarnEnabled(this ILogger logger)
         {
             return logger.IsEnabled(LogEventLevel.Warning);
         }

         public static bool IsWarningEnabled(this ILogger logger)
         {
             return logger.IsEnabled(LogEventLevel.Warning);
         }

         public static bool IsErrorEnabled(this ILogger logger)
         {
             return logger.IsEnabled(LogEventLevel.Error);
         }

         public static bool IsFatalEnabled(this ILogger logger)
         {
             return logger.IsEnabled(LogEventLevel.Fatal);
         }
    }
}