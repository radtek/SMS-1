﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bec.TargetFramework.Infrastructure.Helpers
{

    public class XmlHelper
    {
        public static void ParseToDynamic(dynamic parent, XElement node)
        {
            if (node.HasElements)
            {
                if (node.Elements(node.Elements().First().Name.LocalName).Count() > 1)
                {
                    //list

                    var item = new ExpandoObject();

                    var list = new List<dynamic>();

                    foreach (XElement element in node.Elements())
                    {
                        ParseToDynamic(list, element);
                    }


                    AddProperty(item, node.Elements().First().Name.LocalName, list);

                    AddProperty(parent, node.Name.ToString(), item);
                }

                else
                {
                    var item = new ExpandoObject();


                    foreach (XAttribute attribute in node.Attributes())
                    {
                        AddProperty(item, attribute.Name.ToString(), attribute.Value.Trim());
                    }


                    //element

                    foreach (XElement element in node.Elements())
                    {
                        ParseToDynamic(item, element);
                    }


                    AddProperty(parent, node.Name.ToString(), item);
                }
            }

            else
            {
                AddProperty(parent, node.Name.ToString(), node.Value.Trim());
            }
        }


        private static void AddProperty(dynamic parent, string name, object value)
        {
            if (parent is List<dynamic>)
            {
                (parent as List<dynamic>).Add(value);
            }

            else
            {
                (parent as IDictionary<String, object>)[name] = value;
            }
        }
    }
}
