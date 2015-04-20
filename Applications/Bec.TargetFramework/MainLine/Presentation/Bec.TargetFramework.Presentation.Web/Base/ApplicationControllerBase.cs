using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Bec.TargetFramework.Presentation.Web.Filters;
using EnsureThat;

namespace Bec.TargetFramework.Presentation.Web.Base
{
    /// <summary>
    /// TF Base Controller
    ///// </summary>
    [PreventMultipleLoginsActionFilter]
    //[PreventMultipleSubmitsActionFilter]
    [SessionExpireFilter]
    //[AuditActionFilter(AuditingLevel = 1)]
    [AjaxFriendlyAuthorize]
    public class ApplicationControllerBase : Controller
    {
        private ILogger m_Logger { get; set; }

        public ILogger Logger
        {

            get
            {
                return m_Logger;
            }
        }

        public ApplicationControllerBase(ILogger logger)
        {
            Ensure.That(logger).IsNotNull();

            m_Logger = logger;
        }

        protected ActionResult RespondTo(Action<FormatCollection> format)
        {
            return new FormatResult(format);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ServiceStackJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding
            };
        }

    }

    public class ServiceStackJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                response.Write(JsonSerializer.SerializeToString(Data));
            }
        }
    }

    [DebuggerDisplay("Formats = {string.Join(\", \", Keys)}")]
    public class FormatCollection : Dictionary<string, Func<ActionResult>>
    {
        public ActionResult Default { get; set; }

        public Func<ActionResult> Html { set { this[HtmlKey] = value; } }

        public Func<ActionResult> Xml { set { this[XmlKey] = value; } }

        public Func<ActionResult> Json { set { this[JsonKey] = value; } }

        public Func<ActionResult> Js { set { this[JsKey] = value; } }

        public Func<ActionResult> Csv { set { this[CsvKey] = value; } }

        internal const string HtmlKey = "html";
        internal const string XmlKey = "xml";
        internal const string JsonKey = "json";
        internal const string JsKey = "js";
        internal const string CsvKey = "csv";
    }

    public class FormatResult : ActionResult
    {
        public static MimeTypeList MimeTypes;
        static FormatResult()
        {
            MimeTypes = new MimeTypeList();
            MimeTypes.InitializeDefaults();
        }

        Action<FormatCollection> _format;
        FormatCollection _formatCollection = new FormatCollection();

        public FormatResult(Action<FormatCollection> format)
        {
            _format = format;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            _format(this._formatCollection);
            var result = GetResult(this._formatCollection, context.RouteData.Values, context.HttpContext.Request.AcceptTypes);
            result.ExecuteResult(context);
        }

        public static ActionResult GetResult(FormatCollection formatCollection, RouteValueDictionary routeValues, string[] acceptTypes)
        {
            var format = "html"; // default to html if no format extension is specified
            if (routeValues["format"] == null)
            {
                if (acceptTypes.Any())
                {
                    format = GetFormat(formatCollection, acceptTypes);
                    if (string.IsNullOrEmpty(format))
                    {
                        if (formatCollection.Default != null)
                            return formatCollection.Default;
                        if (formatCollection["html"] != null && acceptTypes.Length == 1 && acceptTypes.First() == "*/*")
                            return formatCollection["html"].Invoke();
                        return new HttpStatusCodeResult(406);
                    }
                }
                else if (!formatCollection.Any())
                {
                    return new HttpStatusCodeResult(406);
                }
            }
            else
            {
                format = routeValues["format"].ToString();
            }

            if (!formatCollection.ContainsKey(format))
            {
                if (formatCollection.Default != null)
                    return formatCollection.Default;
                return new HttpNotFoundResult();
            }

            return formatCollection[format].Invoke();
        }

        public static string GetFormat(FormatCollection formatCollection, string[] acceptTypes)
        {
            foreach (var mimeType in MimeTypes.Parse(acceptTypes))
            {
                foreach (var key in formatCollection.Keys)
                {
                    if (mimeType.Format == key)
                        return key;
                }
            }
            return null;
        }

        /// <summary>
        /// Exposes the action result for unit testing.
        /// </summary>
        /// <returns>
        /// ActionResultExposer intance to call required actions on.
        /// </returns>
        /// <example>
        ///     FormatResult formatResult = 
        ///         new FormatResult(format => format.Json = () => new JsonResult());
        ///     JsonResult jsonResult = (JsonResult)formatResult.ExposeResult().Json();
        /// </example>
        public ActionResultExposer ExposeResult()
        {
            _format(_formatCollection);
            return new ActionResultExposer(_formatCollection);
        }
    }

    public class ActionResultExposer
    {
        readonly FormatCollection formatCollection;

        public ActionResultExposer(FormatCollection formatCollection)
        {
            this.formatCollection = formatCollection;
        }

        public ActionResult Html()
        {
            return ExecuteAction(FormatCollection.HtmlKey);
        }

        public ActionResult Json()
        {
            return ExecuteAction(FormatCollection.JsonKey);
        }

        public ActionResult Js()
        {
            return ExecuteAction(FormatCollection.JsKey);
        }

        public ActionResult Xml()
        {
            return ExecuteAction(FormatCollection.XmlKey);
        }

        public ActionResult Csv()
        {
            return ExecuteAction(FormatCollection.CsvKey);
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

    public class MimeTypeList : List<MimeType>
    {
        Dictionary<string, MimeType> _lookup = new Dictionary<string, MimeType>();
        static MimeType _all = new MimeType("*/*", "all");

        public MimeType Register(string type, string format, params string[] synonyms)
        {
            var mimeType = new MimeType(type, format, synonyms);
            Add(mimeType);
            _lookup[type] = mimeType;
            foreach (var synonym in synonyms)
            {
                _lookup[synonym] = mimeType;
            }
            return mimeType;
        }

        public void Unregister(string type)
        {
            var mimeType = _lookup[type];
            if (mimeType != null)
            {
                _lookup.Remove(type);
                foreach (var synonym in mimeType.Synonyms)
                {
                    _lookup.Remove(synonym);
                }
                Remove(mimeType);
            }
        }

        public MimeType Lookup(string type)
        {
            if (type == "*/*")
                return _all;
            return _lookup[type];
        }

        public MimeType LookupByFormat(string format)
        {
            if (format == "all")
                return _all;
            return this.Where(x => x.Format == format).FirstOrDefault();
        }

        public List<MimeType> Parse(string accept)
        {
            return Parse(accept.Split(',').Select(x => x.Trim()).ToArray());
        }

        public List<MimeType> Parse(params string[] acceptTypes)
        {
            var acceptList = new AcceptList(this, acceptTypes);
            return acceptList.Parse();
        }

        public void InitializeDefaults()
        {
            Register("text/html", "html", "application/xhtml+xml");
            Register("text/plain", "text", "txt");
            Register("text/javascript", "js", "application/javascript", "application/x-javascript");
            Register("text/css", "css");
            Register("text/calendar", "ics");
            Register("text/csv", "csv");
            Register("application/xml", "xml", "text/xml", "application/x-xml");
            Register("application/rss+xml", "rss");
            Register("application/atom+xml", "atom");
            Register("application/x-yaml", "yaml", "text/yaml");

            Register("multipart/form-data", "multipart_form");
            Register("application/x-www-form-urlencoded", "url_encoded_form");

            Register("application/json", "json", "text/x-json", "application/jsonrequest");
        }

        public bool HasType(string type)
        {
            return _lookup.ContainsKey(type) || type == "*/*";
        }

        public IEnumerable<MimeType> Matching(string acceptType)
        {
            foreach (var type in this)
            {
                if (type.Matches(acceptType))
                    yield return type;
            }
        }
    }

    public class MimeType
    {
        public string Type { get; set; }
        public string Format { get; set; }
        public string[] Synonyms { get; set; }

        public MimeType(string type, string format, params string[] synonyms)
        {
            Type = type;
            Format = format;
            Synonyms = synonyms;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Type, Format);
        }

        public bool Matches(string acceptType)
        {
            var regex = new Regex(acceptType);
            return regex.IsMatch(Type) || Synonyms.Any(regex.IsMatch);
        }
    }

    public class AcceptList : List<AcceptType>
    {
        private readonly MimeTypeList _types;

        public AcceptList(MimeTypeList types, params string[] acceptTypes)
        {
            _types = types;
            int order = 0;
            foreach (var acceptType in acceptTypes)
            {
                Add(acceptType, ref order);
            }
            CustomSort();
        }

        void Swap(int indexA, int indexB)
        {
            AcceptType tmp = this[indexA];
            this[indexA] = this[indexB];
            this[indexB] = tmp;
        }

        private void CustomSort()
        {
            Sort();

            var textXml = this.FirstOrDefault(x => x.Type == "text/xml");
            var textXmlIndex = IndexOf(textXml);
            var appXml = this.FirstOrDefault(x => x.Type == "application/xml");
            var appXmlIndex = IndexOf(appXml);

            if (textXml != null && appXml != null)
            {
                // swap text/xml with application/xml and remove text/xml
                appXml.Quality = new[] { textXml.Quality, appXml.Quality }.Max();
                if (appXmlIndex > textXmlIndex)
                {
                    Swap(appXmlIndex, textXmlIndex);
                    appXmlIndex = IndexOf(appXml);
                }
                Remove(textXml);
            }
            else if (textXml != null)
            {
                textXml.Type = "application/xml";
            }

            if (appXml != null)
            {
                // prioritize /xxx+xml over /xml
                var idx = appXmlIndex;
                while (idx < Count)
                {
                    var currentAccept = this[idx];
                    if (currentAccept.Quality < appXml.Quality)
                        break;
                    if (new Regex(@"\+xml$").IsMatch(currentAccept.Type))
                    {
                        Swap(appXmlIndex, idx);
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
                foreach (var mimeType in _types.Matching(acceptType))
                {
                    var at = new AcceptType(mimeType.Type, quality, order);
                    Add(at);
                    order++;
                }
            }
            else
            {
                var at = new AcceptType(type, quality, order);
                Add(at);
                order++;
            }
        }

        public List<MimeType> Parse()
        {
            return this.Where(x => _types.HasType(x.Type)).Select(acceptType => _types.Lookup(acceptType.Type)).Distinct().ToList();
        }
    }

    public class AcceptType : IComparable
    {
        public string Type { get; set; }
        public float Quality { get; set; }
        public int Order { get; set; }

        public AcceptType(string type, float quality, int order)
        {
            Type = type;
            Quality = quality;
            if (type == "*/*")
                Quality = 0;
            Order = order;
        }

        public int CompareTo(object obj)
        {
            var other = (AcceptType)obj;
            var result = other.Quality.CompareTo(Quality);
            if (result == 0)
                result = Order.CompareTo(other.Order);
            return result;
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null)) return false;
            if (object.ReferenceEquals(this, obj)) return true;
            var other = (AcceptType)obj;
            return Type.Equals(other.Type);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Type, Quality, Order);
        }
    }
}
