using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Analysis.Infrastructure;
using System.Resources;
using Bec.TargetFramework.Analysis.Test.Properties;
using Bec.TargetFramework.Infrastructure.Test.Base;

namespace Bec.TargetFramework.Analysis.Test
{
    [TestClass]
    public class XMLTests : UnitTestBase
    {
        [TestMethod]
        public void IsWellFormedXML()
        {
            var xml = string.Empty;
            Assert.IsFalse(xml.IsWellFormedXML());

            xml = "<abc><def/></abc>";
            Assert.IsTrue(xml.IsWellFormedXML());

            xml = "<abc><def/><abc>";
            Assert.IsFalse(xml.IsWellFormedXML());

            xml = Resources.Interaction1RequestSample;
            Assert.IsTrue(xml.IsWellFormedXML());

            xml = Resources.Interaction1ResponseSample;
            Assert.IsTrue(xml.IsWellFormedXML());

            xml = Resources.Interaction2RequestSample;
            Assert.IsTrue(xml.IsWellFormedXML());

            xml = Resources.Interaction2ResponseSample;
            Assert.IsTrue(xml.IsWellFormedXML());

            xml = Resources.Interaction3RequestSample;
            Assert.IsTrue(xml.IsWellFormedXML());
        }

        [TestMethod]
        public void IsValidAgainstXMLSchema()
        {
            var schemas = new string[] { Resources.Schema };

            var errors = string.Empty;
            var xml = string.Empty;
            Assert.IsFalse(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual("<li>Error reading XML document.</li><br /><li>Root element is missing.</li><br />", errors);

            errors = string.Empty;
            xml = "<abc><def/></abc>";
            Assert.IsFalse(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual("<li>Errors ecountered during XML validation.</li><br /><li>Error: The 'abc' element is not declared.<br />Line: 1<br />Position: 2</li>", errors);

            errors = string.Empty;
            xml = "<abc><def/><abc>";
            Assert.IsFalse(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual("<li>Error reading XML document.</li><br /><li>Error: The 'abc' element is not declared.<br />Line: 1<br />Position: 2</li><li>Unexpected end of file has occurred. The following elements are not closed: abc, abc. Line 1, position 17.</li><br />", errors);

            errors = string.Empty;
            xml = Resources.Interaction1RequestSample;
            Assert.IsTrue(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual(string.Empty, errors);

            errors = string.Empty;
            xml = Resources.Interaction1ResponseSample;
            Assert.IsTrue(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual(string.Empty, errors);

            errors = string.Empty;
            xml = Resources.Interaction2RequestSample;
            Assert.IsTrue(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual(string.Empty, errors);

            errors = string.Empty;
            xml = Resources.Interaction2ResponseSample;
            Assert.IsTrue(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual(string.Empty, errors);

            errors = string.Empty;
            xml = Resources.Interaction3RequestSample;
            Assert.IsTrue(xml.IsValidAgainstXMLSchema(schemas, out errors));
            Assert.AreEqual(string.Empty, errors);
        }
    }
}
