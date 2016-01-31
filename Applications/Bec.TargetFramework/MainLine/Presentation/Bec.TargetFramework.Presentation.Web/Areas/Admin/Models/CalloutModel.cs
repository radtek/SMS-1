using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Models
{
    public class CalloutModel
    {

        public List<Entities.CalloutDTO> Callouts { get; set; }

        public Guid CalloutRoleId { get; set; }
    }
}