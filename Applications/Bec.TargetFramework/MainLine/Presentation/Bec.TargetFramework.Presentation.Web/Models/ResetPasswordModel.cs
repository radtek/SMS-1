using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Models
{
    public class ResetPasswordModel
    {
        public string PIN { get; set; }
        public string Username { get; set; }
        public string NewPassword { get; set; }
    }
}