using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Controllers
{
    public class TemplatesController : Controller
    {
        // GET: Templates
        public PartialViewResult KnockoutTemplate(string templateName)
        {
            return PartialView(String.Format("~/Views/Partials/KoTemplates/{0}.cshtml", templateName));
        }
    }
}