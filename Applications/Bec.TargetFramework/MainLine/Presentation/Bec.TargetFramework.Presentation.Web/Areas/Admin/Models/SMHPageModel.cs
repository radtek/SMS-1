using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Models
{
    public class SMHPageModel
    {
        public Guid PageId { get; set; }
        public Guid RoleId { get; set; }
        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public string RoleName { get; set; }
        public bool IsSystemSMH { get; set; }
    }
}