using System.Globalization;
using System.Text;
using System.Web;
using System.Xml;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using System.IO;

namespace Bec.TargetFramework.Infrastructure.NLog
{
    public class LogLogger : ILogger
    {
        private Logger m_Log;

        public LogLogger(Type loggerType)
        {
            m_Log = LogManager.GetLogger("Default");
        }

        public LogLogger()
        {
            m_Log = LogManager.GetLogger("Default");
        }

        public void SetLogger(string name)
        {
            m_Log = LogManager.GetLogger(name);
        }

        public void Trace(string message)
        {
            m_Log.Trace(message);
        }

        public void Trace(string message, params object[] args)
        {
            m_Log.Trace(message,args);
        }

        public void Debug(string message)
        {
            m_Log.Debug(message);
        }
        
        public void Debug(string message, params object[] args)
        {
            m_Log.Debug(message,args);
        }

        public void Info(string message)
        {
            m_Log.Info(message);
        }

        public void Info(string message, params object[] args)
        {
            m_Log.Info(message,args);
        }

        public void Warning(string message)
        {
            m_Log.Warn(message);
        }

        public void Warning(string message, params object[] args)
        {
            m_Log.Warn(message,args);
        }

        public void Error(string message)
        {
            m_Log.Error(message);
        }

        public void Error(string message, params object[] args)
        {
            m_Log.Error(message,args);
        }

        public void Error(Exception exception, string message)
        {
            m_Log.ErrorException(message,exception);
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            m_Log.ErrorException(message, exception);
        }

        public void Fatal(string message)
        {
            m_Log.Fatal(message);
        }

        public void Fatal(string message, params object[] args)
        {
            m_Log.Fatal(message);
        }

        public void Fatal(Exception exception, string message)
        {
            m_Log.ErrorException(message,exception);
        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
            m_Log.Fatal(message, exception);
        }


        public void Error(Exception ex)
        {
            m_Log.Error(ex);
        }
    }

    [LayoutRenderer("utc_date")]
    public class UtcDateRenderer : LayoutRenderer
    {

        ///
        /// Initializes a new instance of the  class.
        ///
        public UtcDateRenderer()
        {
            this.Format = "G";
            this.Culture = CultureInfo.InvariantCulture;
        }

        ///
        /// Gets or sets the culture used for rendering.
        ///
        ///
        public CultureInfo Culture { get; set; }

        ///
        /// Gets or sets the date format. Can be any argument accepted by DateTime.ToString(format).
        ///
        ///
        [DefaultParameter]
        public string Format { get; set; }

        ///
        /// Renders the current date and appends it to the specified .
        ///
        /// <param name="builder">The  to append the rendered data to.
        /// <param name="logEvent">Logging event.
        protected override void Append(System.Text.StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(logEvent.TimeStamp.ToUniversalTime().ToString(this.Format, this.Culture));
        }

    }
    public class LogUtility
    {

        public static string BuildExceptionMessage(Exception x)
        {

            Exception logException = x;
            if (x.InnerException != null)
                logException = x.InnerException;

            string strErrorMsg = Environment.NewLine + "Error in Path :" + System.Web.HttpContext.Current.Request.Path;

            // Get the QueryString along with the Virtual Path
            strErrorMsg += Environment.NewLine + "Raw Url :" + System.Web.HttpContext.Current.Request.RawUrl;

            // Get the error message
            strErrorMsg += Environment.NewLine + "Message :" + logException.Message;

            // Source of the message
            strErrorMsg += Environment.NewLine + "Source :" + logException.Source;

            // Stack Trace of the error

            strErrorMsg += Environment.NewLine + "Stack Trace :" + logException.StackTrace;

            // Method where the error occurred
            strErrorMsg += Environment.NewLine + "TargetSite :" + logException.TargetSite;
            return strErrorMsg;
        }
    }

    [LayoutRenderer("web_variables")]
    public class WebVariablesRenderer : LayoutRenderer
    {

        ///
        /// Initializes a new instance of the  class.
        ///
        public WebVariablesRenderer()
        {
            this.Format = "";
            this.Culture = CultureInfo.InvariantCulture;
        }


        ///
        /// Gets or sets the culture used for rendering.
        ///
        ///
        public CultureInfo Culture { get; set; }

        ///
        /// Gets or sets the date format. Can be any argument accepted by DateTime.ToString(format).
        ///
        ///
        [DefaultParameter]
        public string Format { get; set; }

        ///
        /// Renders the current date and appends it to the specified .
        ///
        /// <param name="builder">The  to append the rendered data to.
        /// <param name="logEvent">Logging event.
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);

            writer.WriteStartElement("error");

            // -----------------------------------------
            // Server Variables
            // -----------------------------------------
            writer.WriteStartElement("serverVariables");

            foreach (string key in HttpContext.Current.Request.ServerVariables.AllKeys)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("name", key);

                writer.WriteStartElement("value");
                writer.WriteAttributeString("string", HttpContext.Current.Request.ServerVariables[key].ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            // -----------------------------------------
            // Cookies
            // -----------------------------------------
            writer.WriteStartElement("cookies");

            foreach (string key in HttpContext.Current.Request.Cookies.AllKeys)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("name", key);

                writer.WriteStartElement("value");
                writer.WriteAttributeString("string", HttpContext.Current.Request.Cookies[key].Value.ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            // -----------------------------------------

            writer.WriteEndElement();
            // -----------------------------------------

            writer.Flush();
            writer.Close();

            string xml = sb.ToString();

            builder.Append(xml);
        }

    }
}
