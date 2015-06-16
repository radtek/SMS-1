using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Helpers
{
    public static class ExceptionHelper
    {
        public static string FlattenException(this Exception exception)
        {
            var stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);
                stringBuilder.AppendLine();

                if (exception.Data.Count > 0)
                {
                    stringBuilder.AppendLine("Data Items");
                    stringBuilder.AppendLine();
                }
                    
                exception.Data.Keys.OfType<object>().ToList()
                    .ForEach(
                        item =>
                        {
                            if (item != null && exception.Data[item] != null)
                            {
                                stringBuilder.AppendLine(
                                    "Data Key:" + item + " value:" + exception.Data[item].ToString());
                            }
                        });

                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Executed By:" + Environment.UserName);
                stringBuilder.AppendLine("Executed On:" + Environment.MachineName);

                exception = exception.InnerException;
            }

            return stringBuilder.ToString();
        }

        public static string FlattenExceptionJson(this Exception exception)
        {
            var stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);
                stringBuilder.AppendLine();

                if (exception.Data.Count > 0)
                {
                    stringBuilder.AppendLine("Data Items");
                    stringBuilder.AppendLine();
                }

                exception.Data.Keys.OfType<object>().ToList()
                    .ForEach(
                        item =>
                        {
                            if (item != null && exception.Data[item] != null)
                            {
                                stringBuilder.AppendLine(
                                    "Data Key:" + item + " value:" + exception.Data[item].ToString());
                            }
                        });

                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Executed By:" + Environment.UserName);
                stringBuilder.AppendLine("Executed On:" + Environment.MachineName);

                exception = exception.InnerException;
            }

            return stringBuilder.ToString();
        }
    }
}
