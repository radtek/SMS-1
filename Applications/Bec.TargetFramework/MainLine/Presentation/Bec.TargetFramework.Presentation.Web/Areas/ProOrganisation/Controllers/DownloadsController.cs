﻿using Bec.TargetFramework.Business.Client.Interfaces;
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

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers
{
    [ClaimsRequired("View", "Products", Order = 1000)]
    public class DownloadsController : ApplicationControllerBase
    {
        public IOrganisationLogicClient orgClient { get; set; }
        public IQueryLogicClient queryClient { get; set; }

        // GET: ProOrganisation/Users
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SchemeLogo(ImageFormat format)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<OrganisationDTO>(x => new { x.SchemeID });
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgID);
            var ret = await queryClient.QueryAsync<OrganisationDTO>("Organisations", select + filter);
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
    }
}