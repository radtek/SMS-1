using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.UI.Process.Base
{
    public class MimeTypeList : List<MimeType>
    {
        private readonly Dictionary<string, MimeType> _lookup = new Dictionary<string, MimeType>();
        private static readonly MimeType _all = new MimeType("*/*", "all");

        public MimeType Register(string type, string format, params string[] synonyms)
        {
            var mimeType = new MimeType(type, format, synonyms);
            this.Add(mimeType);
            this._lookup[type] = mimeType;
            foreach (var synonym in synonyms)
            {
                this._lookup[synonym] = mimeType;
            }
            return mimeType;
        }

        public void Unregister(string type)
        {
            var mimeType = this._lookup[type];
            if (mimeType != null)
            {
                this._lookup.Remove(type);
                foreach (var synonym in mimeType.Synonyms)
                {
                    this._lookup.Remove(synonym);
                }
                this.Remove(mimeType);
            }
        }

        public MimeType Lookup(string type)
        {
            if (type == "*/*")
            {
                return _all;
            }
            return this._lookup[type];
        }

        public MimeType LookupByFormat(string format)
        {
            if (format == "all")
            {
                return _all;
            }
            return this.Where(x => x.Format == format).FirstOrDefault();
        }

        public List<MimeType> Parse(string accept)
        {
            return this.Parse(accept.Split(',').Select(x => x.Trim()).ToArray());
        }

        public List<MimeType> Parse(params string[] acceptTypes)
        {
            var acceptList = new AcceptList(this, acceptTypes);
            return acceptList.Parse();
        }

        public void InitializeDefaults()
        {
            this.Register("text/html", "html", "application/xhtml+xml");
            this.Register("text/plain", "text", "txt");
            this.Register("text/javascript", "js", "application/javascript", "application/x-javascript");
            this.Register("text/css", "css");
            this.Register("text/calendar", "ics");
            this.Register("text/csv", "csv");
            this.Register("application/xml", "xml", "text/xml", "application/x-xml");
            this.Register("application/rss+xml", "rss");
            this.Register("application/atom+xml", "atom");
            this.Register("application/x-yaml", "yaml", "text/yaml");

            this.Register("multipart/form-data", "multipart_form");
            this.Register("application/x-www-form-urlencoded", "url_encoded_form");

            this.Register("application/json", "json", "text/x-json", "application/jsonrequest");
        }

        public bool HasType(string type)
        {
            return this._lookup.ContainsKey(type) || type == "*/*";
        }

        public IEnumerable<MimeType> Matching(string acceptType)
        {
            foreach (var type in this)
            {
                if (type.Matches(acceptType))
                {
                    yield return type;
                }
            }
        }
    }
}