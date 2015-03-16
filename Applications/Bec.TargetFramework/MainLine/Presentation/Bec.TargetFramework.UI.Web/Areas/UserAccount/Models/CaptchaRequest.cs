using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.UI.Web.Areas.UserAccount.Models
{
    public class CaptchaRequest
    {
        public string PublicKey { get; set; }

        public string Challenge { get; set; }

        public string Response { get; set; }
    }
}