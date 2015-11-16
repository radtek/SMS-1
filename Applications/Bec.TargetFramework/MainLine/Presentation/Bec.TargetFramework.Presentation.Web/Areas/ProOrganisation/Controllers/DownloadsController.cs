using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers
{
    [ClaimsRequired("View", "Products", Order = 1000)]
    public class DownloadsController : ApplicationControllerBase
    {
        public IBankAccountLogicClient BankAccountClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }
        public INotificationLogicClient NotificationClient { get; set; }

        // GET: ProOrganisation/Users
        public async Task<ActionResult> Index()
        {
            if (ClaimsHelper.UserHasClaim("View", "BankAccount"))
            {
                var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
                var accs = await BankAccountClient.GetOrganisationBankAccountsAsync(orgID);
                ViewBag.BankAccounts = accs.Where(x => x.IsActive && x.Status == BankAccountStatusEnum.Safe.GetStringValue());
            }
            return View();
        }

        public async Task<ActionResult> SchemeLogo(ImageFormat format)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<OrganisationDTO>(x => new { x.SchemeID });
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgID);
            var ret = await QueryClient.QueryAsync<OrganisationDTO>("Organisations", select + filter);
            var sid = ret.First().SchemeID;

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            var cd = codecs.First(codec => codec.FormatID == format.Guid);
            var ext = cd.FilenameExtension.Split(';').First().Trim('*');

            var img = Image.FromFile(Server.MapPath("~/content/WelcomePack/SMS Member Logo.jpg"));
            using (var gr = Graphics.FromImage(img))
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.DrawString(sid.ToString(), new Font("Tahoma", 32), Brushes.White, new RectangleF(427, 278, 700, 380));
                using (var stream = new MemoryStream())
                {
                    img.Save(stream, format);
                    var data = stream.ToArray();
                    return File(data, cd.MimeType, "SMS Scheme Logo" + ext);
                }
            }
        }

        static string GetMimeType(ImageFormat imageFormat)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            return codecs.First(codec => codec.FormatID == imageFormat.Guid).MimeType;
        }

        public ActionResult HowToUse()
        {
            return File(Server.MapPath("~/content/WelcomePack/How To Use the Safe Move Scheme a Guide For Firms.pdf"), "application/pdf", "How To Use the Safe Move Scheme a Guide For Firms.pdf");
        }

        public ActionResult LogoUsageGuidelines()
        {
            return File(Server.MapPath("~/content/WelcomePack/Logo Usage Guidelines.pdf"), "application/pdf", "Logo Usage Guide.pdf");
        }

        public ActionResult QuickStart()
        {
            return File(Server.MapPath("~/content/WelcomePack/Quick Start Guide for Professionals.pdf"), "application/pdf", "Quick Start guide for Professional Users.pdf");
        }

        public ActionResult CreatingAccount()
        {
            return File(Server.MapPath("~/content/WelcomePack/SMS Professional Users - Creating Your Account.pdf"), "application/pdf", "SMS - Creating a new account.pdf");
        }

        public ActionResult Faq()
        {
            return File(Server.MapPath("~/content/WelcomePack/SMS Frequently Asked Questions.pdf"), "application/pdf", "SMS Frequently Asked Questions.pdf");
        }

        public ActionResult BuyersAndSMS()
        {
            return File(Server.MapPath("~/content/WelcomePack/Buyers and the SMS.pdf"), "application/pdf", "Buyers and the SMS.pdf");
        }

        public ActionResult SafeBuyer()
        {
            return File(Server.MapPath("~/content/WelcomePack/SMS - Safe Buyer.pdf"), "application/pdf", "SMS - Safe Buyer.pdf");
        }

        public async Task<ActionResult> ClientTsCs()
        {
            var name = NotificationConstructEnum.TcPublic.GetStringValue();
            var ncSelect = ODataHelper.Select<NotificationConstructDTO>(x => new { x.NotificationConstructID, x.NotificationConstructVersionNumber });
            var ncFilter = ODataHelper.Filter<NotificationConstructDTO>(x => x.Name == name);
            var ncs = await QueryClient.QueryAsync<NotificationConstructDTO>("NotificationConstructs", ncSelect + ncFilter);
            var nc = ncs.OrderByDescending(n => n.NotificationConstructVersionNumber).First();

            var data = await NotificationClient.RetrieveNotificationConstructDataAsync(nc.NotificationConstructID, nc.NotificationConstructVersionNumber, null);

            return File(data, "application/pdf", string.Format("Safe Buyer Terms And Conditions.pdf"));
        }
    }
}