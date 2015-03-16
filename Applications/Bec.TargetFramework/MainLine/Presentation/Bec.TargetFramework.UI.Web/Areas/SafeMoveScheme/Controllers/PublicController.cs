using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC;
using Ext.Net;

namespace Bec.TargetFramework.UI.Web.Areas.SafeMoveScheme.Controllers
{
    public class PublicController : Controller
    {
        //
        // GET: /SafeMoveScheme/Public/


        public ActionResult Index()
        {
            return RedirectToAction("Index", "Default", new { area = "SafeMoveScheme" });
        }
        public ActionResult Home()
        {
            return View();
        }

 

        public ActionResult KiteMark()
        {
            return View();
        }

        public ActionResult BuyingProperty()
        {
            return View();
        }

        public ActionResult SellingProperty()
        {
            return View();
        }


        public ActionResult TrustedProfessional()
        {
            return View();
        }

        public ActionResult EstateAgents()
        {
            return View();
        }

        public ActionResult MortgageAdvisers()
        {
            return View();
        }

        public ActionResult Lawyers()
        {

            return View();
        }

        public ActionResult MortgageLenders()
        {
            return View();
        }


    }

}