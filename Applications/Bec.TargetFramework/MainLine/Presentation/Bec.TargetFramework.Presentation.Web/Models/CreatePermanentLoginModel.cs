using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Models
{
    public class CreatePermanentLoginModel
    {
        public string Email { get; set; }
        public string Pin { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}