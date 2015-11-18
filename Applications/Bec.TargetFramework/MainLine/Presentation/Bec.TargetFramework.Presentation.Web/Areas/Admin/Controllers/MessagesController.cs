using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.App_Helpers;
using Bec.TargetFramework.Presentation.Web.Base;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesController : ApplicationControllerBase
    {
        public ActionResult Index()
        {

            return View();
        }
    }

    public class Discussion
    {
        public string Subject { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FirstUnreadUser { get; set; }
        public string FirstUnreadMessage { get; set; }
    }

}