using System.Collections.Generic;

namespace Bec.TargetFramework.Presentation.Web.Models
{
    public class FaqGroup
    {
        public string Name { get; set; }
        public IEnumerable<Faq> Faqs { get; set; }
    }
}