using System;
using System.Web.Mvc;

namespace Bec.TargetFramework.UI.Process.Base
{
    public class ActionResultExposer
    {
        private readonly FormatCollection formatCollection;

        public ActionResultExposer(FormatCollection formatCollection)
        {
            this.formatCollection = formatCollection;
        }

        public ActionResult Html()
        {
            return this.ExecuteAction(FormatCollection.HtmlKey);
        }

        public ActionResult Json()
        {
            return this.ExecuteAction(FormatCollection.JsonKey);
        }

        public ActionResult Js()
        {
            return this.ExecuteAction(FormatCollection.JsKey);
        }

        public ActionResult Xml()
        {
            return this.ExecuteAction(FormatCollection.XmlKey);
        }

        public ActionResult Csv()
        {
            return this.ExecuteAction(FormatCollection.CsvKey);
        }

        private ActionResult ExecuteAction(string key)
        {
            if (!this.formatCollection.ContainsKey(key))
            {
                string message = string.Format("Format you are trying to get is not registered. Requested format is {0}. Registered formats are {1}",
                    key, string.Join(", ", this.formatCollection.Keys));
                throw new Exception(message);
            }

            return this.formatCollection[key]();
        }
    }
}