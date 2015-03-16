using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC;
using Data = Bec.TargetFramework.UI.Web.Models.Data;
using Bec.TargetFramework.UI.Process.Filters;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Security;


namespace Bec.TargetFramework.UI.Web.Controllers
{
    
    public class PortalController : ApplicationControllerBase
    {
        public PortalController(ILogger logger)
            : base(logger)
        {

        }
        //
        // GET: /Portal/
        //[ClaimsAuthorize("View","Portal")]
        public ActionResult Index()
        {
            return View();
        }
    }
}