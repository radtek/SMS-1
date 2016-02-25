using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Models
{
    public class SafeSendGroupEditEntry
    {
        public Guid SafeSendGroupID { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public bool IsChecked { get; set; }
    }
}