using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Models
{
    public class CaptchaResponse
    {
        public bool success { get; set; }
        public List<string> error_codes { get; set; }
    }
}