using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bec.TargetFramework.UI.Process.Base
{
    public class AcceptList : List<AcceptType>
    {
        private readonly MimeTypeList _types;

        public AcceptList(MimeTypeList types, params string[] acceptTypes)
        {
            this._types = types;
            int order = 0;
            foreach (var acceptType in acceptTypes)
            {
                this.Add(acceptType, ref order);
            }
            this.CustomSort();
        }

        private void Swap(int indexA, int indexB)
        {
            AcceptType tmp = this[indexA];
            this[indexA] = this[indexB];
            this[indexB] = tmp;
        }

        private void CustomSort()
        {
            this.Sort();

            var textXml = this.FirstOrDefault(x => x.Type == "text/xml");
            var textXmlIndex = this.IndexOf(textXml);
            var appXml = this.FirstOrDefault(x => x.Type == "application/xml");
            var appXmlIndex = this.IndexOf(appXml);

            if (textXml != null && appXml != null)
            {
                // swap text/xml with application/xml and remove text/xml
                appXml.Quality = new[] { textXml.Quality, appXml.Quality }.Max();
                if (appXmlIndex > textXmlIndex)
                {
                    this.Swap(appXmlIndex, textXmlIndex);
                    appXmlIndex = this.IndexOf(appXml);
                }
                this.Remove(textXml);
            }
            else if (textXml != null)
            {
                textXml.Type = "application/xml";
            }

            if (appXml != null)
            {
                // prioritize /xxx+xml over /xml
                var idx = appXmlIndex;
                while (idx < this.Count)
                {
                    var currentAccept = this[idx];
                    if (currentAccept.Quality < appXml.Quality)
                    {
                        break;
                    }
                    if (new Regex(@"\+xml$").IsMatch(currentAccept.Type))
                    {
                        this.Swap(appXmlIndex, idx);
                        appXmlIndex = idx;
                    }
                    idx++;
                }
            }
        }

        public void Add(string acceptType, ref int order)
        {
            string type = acceptType;
            float quality = 1;
            if (acceptType.Contains(";"))
            {
                var typeAndQuality = acceptType.Split(';');
                type = typeAndQuality.First();
                var attributes = typeAndQuality.Last().Trim().Split('=');
                if (attributes.Length == 2)
                {
                    float.TryParse(attributes.Last(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out quality);
                }
            }
            if (new Regex(@"(application|text|image)/\*").IsMatch(acceptType))
            {
                foreach (var mimeType in this._types.Matching(acceptType))
                {
                    var at = new AcceptType(mimeType.Type, quality, order);
                    this.Add(at);
                    order++;
                }
            }
            else
            {
                var at = new AcceptType(type, quality, order);
                this.Add(at);
                order++;
            }
        }

        public List<MimeType> Parse()
        {
            return this.Where(x => this._types.HasType(x.Type)).Select(acceptType => this._types.Lookup(acceptType.Type)).Distinct().ToList();
        }
    }
}