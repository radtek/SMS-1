using System.Xml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Formatting = Newtonsoft.Json.Formatting;
using Newtonsoft.Json.Serialization;

namespace Bec.TargetFramework.Infrastructure.Helpers
{
    public class JsonHelper
    {
        public static string DeserialiseJsonToXml(string json)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json);

            return doc.OuterXml;
        }

        public static string SerialiseXMLToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            return jsonText;
        }

        public static T DeserializeData<T>(string content)
        {
            var obj = JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });

            return obj;
        }

        public static string SerializeData<T>(T content)
        {
            return JsonConvert.SerializeObject(content, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });

        }

        public static string SerializeDataUnformattedWithCamelCase<T>(T content)
        {
            return JsonConvert.SerializeObject(content, Formatting.None,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.None,
                    StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

    }
}
