using Bec.TargetFramework.Analysis;
using Bec.TargetFramework.Analysis.Infrastructure.Helpers;
using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Bec.TargetFramework.Analysis.Infrastructure
{
    public static class SearchDetailHelper
    {
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), "http://ipg-online.com/ipgapi/schemas/ipgapi");
            return (T)serializer.Deserialize(new StringReader(xml));
        }

        public static string Serialize<T>(T dto)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xsSubmit = new System.Xml.Serialization.XmlSerializer(typeof(T));
            StringWriterWithEncoding sww = new StringWriterWithEncoding(Encoding.UTF8);
            var writer = XmlWriter.Create(sww);
            xsSubmit.Serialize(writer, dto, ns);
            return sww.ToString(); // Your xml
        }
    }
}
