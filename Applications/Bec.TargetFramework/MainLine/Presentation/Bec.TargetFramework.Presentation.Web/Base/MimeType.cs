using System.Linq;
using System.Text.RegularExpressions;

namespace Bec.TargetFramework.UI.Process.Base
{
    public class MimeType
    {
        public string Type { get; set; }

        public string Format { get; set; }

        public string[] Synonyms { get; set; }

        public MimeType(string type, string format, params string[] synonyms)
        {
            this.Type = type;
            this.Format = format;
            this.Synonyms = synonyms;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", this.Type, this.Format);
        }

        public bool Matches(string acceptType)
        {
            var regex = new Regex(acceptType);
            return regex.IsMatch(this.Type) || this.Synonyms.Any(regex.IsMatch);
        }
    }
}