using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        [ActionName("404")]
        public ActionResult FourHundredFour()
        {
            Response.StatusCode = 404;
            return View();
        }

        [ActionName("500")]
        public ActionResult FiveHundred(Exception ex)
        {
            
            Response.StatusCode = 500;
            return View(ex);
        }
    }
}