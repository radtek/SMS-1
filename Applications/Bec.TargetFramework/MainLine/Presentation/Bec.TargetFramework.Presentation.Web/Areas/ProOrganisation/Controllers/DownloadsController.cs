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

namespace Bec.TargetFramework.Presentation.Web.Areas.ProOrganisation.Controllers
{
    [ClaimsRequired("Add", "ProUsers", Order = 1000)]
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

            var img = Image.FromFile(Server.MapPath("~/content/SchemeLogo.png"));
            using (var gr = Graphics.FromImage(img))
            {
                gr.DrawString(sid.ToString(), new Font("Century Gothic", 144), Brushes.Black, new RectangleF(1700, 1080, 900, 350));
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

        public ActionResult WelcomePack()
        {
            return File(Server.MapPath("~/content/WelcomePack.pdf"), "application/pdf", "WelcomePack.pdf");
        }
    }
}