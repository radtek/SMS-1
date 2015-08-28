
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.ExperianIDCheck;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Settings;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Helpers;
//using Fabrik.Common;
using ServiceStack.Text;
using EnsureThat;
using System.Xml;
using System.Xml.Serialization;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class ExperianIDCheckLogic : LogicBase, IExperianIDCheckLogic
    {
        private readonly ExperianIDCheckSettings idSettings;

        public ExperianIDCheckLogic(ILogger logger, ICacheProvider cacheProvider,
            ExperianIDCheckSettings idcheckSettings)
            : base(logger, cacheProvider)
        {
            idSettings = idcheckSettings;
        }

        public string PerformExperianProveIDQuery(Bec.TargetFramework.Entities.Experian.Search searchRequest)
        {
            ExperianHelper.EnsureExperianSettingsAreValid(idSettings, "Experian ProveID Error");

            var xmlSearchRequest = CreateSearchRequestXmlRepresentation(searchRequest);
          
            var idCheckSearch = new IDSearch();

            var response = string.Empty;

            try
            {
                // perform an id check
                response = idCheckSearch.search(xmlSearchRequest);

                // create dynamic response object so we can extract and query the values
                var dynamicResponse = CreateDynamicExpandoFromXmlResponse(response);

                if (m_ErrorCodes.Count > 0)
                    throw new Exception("Experian ProveID Error");

                // check for search object
                if (SearchExistsInResult(dynamicResponse as IDictionary<string, object>))
                {
                    // check whether an error has taken place e.g. the existance of an ErrorCode object
                    if (ErrorSearchExistsInResult(dynamicResponse as IDictionary<string, object>, "ErrorCode"))
                    {
                        string errorCode = dynamicResponse.Search.ErrorCode;
                        string errorMessage
                            = dynamicResponse.Search.ErrorMessage;
                    }
                }
                else
                    throw new Exception("Experian ProveID Error: Search element does not exist in response");
            }
            catch (Exception ex )
            {
                Exception e = new ArgumentException("Experian ProveID Error",ex);

                // dump errors into exception
                if(m_ErrorCodes.Count > 0)
                e.Data.Add("ErrorCodes", m_ErrorCodes.Dump());

                // dump request into exception
                e.Data.Add("Request", searchRequest.Dump());

                // log exception
                Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = e
                });


                throw ex;
            }

            return response;
        }

        private bool SearchExistsInResult(IDictionary<string,object> dictionary)
        {
            bool exists = false;

            if(dictionary.ContainsKey("Search"))
                exists =  true;

            return exists;
        }

        private bool ErrorSearchExistsInResult(IDictionary<string, object> dictionary, string key)
        {
            bool exists = false;

            if (dictionary.ContainsKey("Search") && (dictionary["Search"] is IDictionary<string, object>)
                && (dictionary["Search"] as IDictionary<string, object>).ContainsKey(key)) 
             exists =  true;
          
            return exists;
        }

        private List<Tuple<int, string, string>> m_ErrorCodes = new List<Tuple<int, string, string>>();

        void DeconstructHierarchy(XElement element,XElement parent, int depth)
        {
            // For simplicity, argument validation not performed
            if (element.HasElements &&  element.HasAttributes && element.Attributes().Any(a => a.Name.LocalName.Equals("Type") && a.Value.Equals("Error")))
            {
                var errorCodeValue = element.Elements().Single(s => s.Name.LocalName.Equals("ErrorCode")).Value;
                var errorMessage = element.Elements().Single(s => s.Name.LocalName.Equals("ErrorMessage")).Value;
                var parentElementName = element.Name.LocalName;

                if (!m_ErrorCodes.Contains(new Tuple<int, string, string>(int.Parse(errorCodeValue), errorMessage, parentElementName)))
                    m_ErrorCodes.Add(new Tuple<int, string, string>(int.Parse(errorCodeValue), errorMessage, parentElementName));
            }

            if (!element.HasElements)
            {
                Console.WriteLine
                (
                    string.Format
                    (
                        "{0}<{1}>{2}</{1}>",
                        "".PadLeft(depth, '\t'), // {0}
                        element.Name.LocalName,  // {1}
                        element.Value            // {2}
                    )
                );
            }
            else
            {
                Console.WriteLine
                (
                    "".PadLeft(depth, '\t') + // Indent to show depth
                    "<" + element.Name.LocalName + ">"
                );

                depth++;

                foreach (XElement child in element.Elements())
                {
                    DeconstructHierarchy(child,element, depth);
                }

                depth--;

                Console.WriteLine
                (
                    "".PadLeft(depth, '\t') + // Indent to show depth
                    "</" + element.Name.LocalName + ">"
                );
            }
        }


        /// <summary>
        /// Converts a Experian.Search (ProveID) to XML
        /// </summary>
        private string CreateSearchRequestXmlRepresentation(Bec.TargetFramework.Entities.Experian.Search searchRequest)
        {
            string xmlSearch = string.Empty;

            searchRequest.Authentication = new Bec.TargetFramework.Entities.Experian.SearchAuthentication();

            searchRequest.Authentication.Password = idSettings.Password;
            searchRequest.Authentication.Username = idSettings.UserName;

            // set product code
            searchRequest.SearchOptions.ProductCode = idSettings.ProductCode;

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xsSubmit = new System.Xml.Serialization.XmlSerializer(searchRequest.GetType());
            StringWriter sww = new StringWriter();
            var writer = XmlWriter.Create(sww);
            xsSubmit.Serialize(writer, searchRequest, ns);
            xmlSearch = sww.ToString(); // Your xml

            // remove xml header
            xmlSearch = xmlSearch.Remove(0, 39);

            // set address current = 1 to xml
            xmlSearch = xmlSearch.Replace("<Address>", @"<Address Current=""1"">");

            return xmlSearch;
        }

        private dynamic CreateDynamicExpandoFromXmlResponse(string response)
        {
            XDocument xDoc = XDocument.Parse(response);

            Ensure.That(xDoc.Elements().Any()).IsNot(false);

            dynamic root = new ExpandoObject();

            DeconstructHierarchy(xDoc.Root, null, 5);

            // parse to dynamic object
            XmlHelper.ParseToDynamic(root, xDoc.Elements().First());

            return root;
        }
    }
}