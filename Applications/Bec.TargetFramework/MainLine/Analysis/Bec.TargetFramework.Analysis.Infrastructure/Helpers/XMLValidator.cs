using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Bec.TargetFramework.Analysis.Infrastructure.Helpers
{
    public class XMLValidator : IDisposable
    {
        private string[] _xsd;
        private string _xml;
        private string _result;
        private int _errorCount;

        public XMLValidator(string xml)
        {
            _xml = xml;            
        }

        public XMLValidator(string xml, string[] xsd) 
            : this(xml)
        {
            _xsd = xsd;
        }

        private XmlReaderSettings GetSettings()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEvent);
            //settings.XmlResolver = new XmlLocalResolver(_localcache);

            settings.Schemas = GetSchemaSets();
            return settings;
        }

        private XmlSchemaSet GetSchemaSets()
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            //XmlLocalResolver localResolver = new XmlLocalResolver(_localcache);
            //schemaSet.XmlResolver = localResolver;
            
            for (int i = 0; i < _xsd.Length; i++)
                if (_xsd[i] != "") schemaSet.Add("", XmlReader.Create(new StringReader(_xsd[i])));    
            
            return schemaSet;
        }

        public bool Validate(out string errors)
        {
            try
            {
                errors = string.Empty;
                _result = string.Empty;
                XmlReaderSettings settings = GetSettings();                

                using (var validationReader = XmlReader.Create(new StringReader(_xml), settings))
                {
                    try
                    {
                        while (validationReader.Read())
                        {
                            if (_errorCount > 10)
                            {
                                errors = ("<li>Too many errors. XML validation stopped.</li><br />") + _result;
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errors = ("<li>Error reading XML document.</li><br />") + _result + "<li>" + ex.Message + "</li><br />";
                        return false;
                    }
                    finally
                    {
                        validationReader.Close();
                    }
                }

                if (_errorCount > 0)
                {
                    errors = ("<li>Errors ecountered during XML validation.</li><br />") + _result;
                    return false;
                }
                return true;
            }

            catch (XmlSchemaValidationException xmlEx)
            {
                throw new XmlSchemaValidationException(xmlEx.Message.ToString(), xmlEx.InnerException);
            }
            catch (XmlException xmlEx)
            {
                throw new XmlSchemaValidationException(xmlEx.Message.ToString(), xmlEx.InnerException);
            }
        }

        private void ValidationEvent(object sender, ValidationEventArgs args)
        {
            _errorCount++;
            switch (args.Severity)
            {
            case XmlSeverityType.Error:
                _result += ("<li>Error: " + args.Message);
                break;
            case XmlSeverityType.Warning:
                _result += ("<li>Warning: " + args.Message);
                break;
            }
            _result += ("<br />Line: " + args.Exception.LineNumber + "<br />Position: " + args.Exception.LinePosition + "</li>");
        }

        public bool IsWellFormed()
        {
            using (XmlReader xr = XmlReader.Create(
                    new StringReader(_xml)))
            {
                try
                {
                    while (xr.Read()) { }
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public void Dispose()
        {
            _xsd = null;
            _xml = null;
            _result = null;
        }
    }
}
