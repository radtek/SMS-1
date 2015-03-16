using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bec.DynamicForms.ServiceLayer.BusinessLogic;

namespace Bec.DynamicForms.ServiceLayer
{
    public  static class Util
    {
        public static string IsChecked(string arrObjects, string selectedOption)
        {
            char[] separators = { '|', '|', };
            string[] strArray = arrObjects.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length > 0)
            {
                
                    foreach (string field in strArray)
                    {
                        if (field == selectedOption)
                        {
                            return "checked=\"checked\"";
                        }
                    }
                
            }
                return "";
        }
        public static void CopyToNew(this object S, object T)
        /* Simple extension method to copy all public properties. Works for any objects and does not require class to be [Serializable]. 
         *   Can be extended for other access level.
         * If the two objects are of the same type, it would make more sense to make this a generic method with a single type parameter 
         * to enforce that. If they are not the same type, you'll have to handle the possibility that properties with the same name might
         * have incompatible types. For example, S might have a property called "ID" of type int, while T's ID property might be a Guid
         */
        {
            if (S != null)
            {
                foreach (var pS in S.GetType().GetProperties())
                {
                    foreach (var pT in T.GetType().GetProperties())
                    {
                        if (pT.Name != pS.Name) continue;
                        (pT.GetSetMethod()).Invoke(T, new object[] { pS.GetGetMethod().Invoke(S, null) });
                    }
                }
            }
        }
        public static string GetXmlDocument(List<genericBO> strvalues, string[] attributes, string parentNode, string childNode, string childElement)
        {
            StringBuilder xmlBuilder = new StringBuilder();
            try
            {
                XmlWriter xw = XmlWriter.Create(xmlBuilder);
                ;

                xw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"utf-8\"");
                xw.WriteStartElement(parentNode);
                foreach (var objString in strvalues)
                {
                    xw.WriteStartElement(childNode);
                    xw.WriteStartElement(childElement);
                    //loop through attributes
                    int iflag = 0;
                    foreach (string strAttribute in attributes)
                    {
                        if (iflag == 0)
                            xw.WriteAttributeString(strAttribute, objString.Title);
                        if (iflag == 1)
                            xw.WriteAttributeString(strAttribute, objString.Description);
                        iflag++;
                    }
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                }
                xw.WriteEndElement();
                xw.Close();
            }
            catch (Exception ex)
            {
            }
            return xmlBuilder.ToString();
        }

        public static List<genericBO> GetNodeValues(string nodeName, string xmlData)
        {
            StringBuilder sb1 = new StringBuilder();
            List<genericBO> nodes = new List<genericBO>();

            if (!string.IsNullOrEmpty(xmlData))
            {
                sb1.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sb1.AppendLine(xmlData);

                try
                {
                    XmlDocument xd = new XmlDocument();
                    xd.LoadXml(sb1.ToString());
                    XmlNodeList nodeList = xd.GetElementsByTagName(nodeName);
                    genericBO objString = null;
                    if (nodeList != null)
                    {
                        foreach (XmlNode node in nodeList)
                        {
                            objString = new genericBO();
                            string strTitle = string.Empty;
                            string strValue = string.Empty;

                            foreach (XmlAttribute attribute in node.Attributes)
                            {
                                if (string.IsNullOrEmpty(strTitle))
                                    strTitle = attribute.Value;
                                else
                                    strValue = attribute.Value;
                            }
                            objString.Title = strTitle;
                            objString.Description = strValue;
                            nodes.Add(objString);
                        }
                    }

                }
                catch (Exception ex)
                {
                }
            }
            return nodes;
        }

    }
}
