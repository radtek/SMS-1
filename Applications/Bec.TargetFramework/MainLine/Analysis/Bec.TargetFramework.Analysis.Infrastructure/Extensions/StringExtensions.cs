using Bec.TargetFramework.Analysis.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Bec.TargetFramework.Analysis.Infrastructure
{
    public static class StringExtensions
    {
        public static bool IsWellFormedXML(this string value)
        {
            using (XMLValidator validator = new XMLValidator(value))
                return validator.IsWellFormed();
        }

        public static bool IsValidAgainstXMLSchema(this string value, string[] xsdAsText, out string errors)
        {
            using (XMLValidator validator = new XMLValidator(value, xsdAsText))
                return validator.Validate(out errors);
        }
    }
}
