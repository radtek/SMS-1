using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.App_Helpers
{
    public class PdfContentResult : FileResult
    {
        public PdfContentResult()
            : base(System.Net.Mime.MediaTypeNames.Application.Pdf)
        {
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            response.OutputStream.Write(this.FileContents, 0, this.FileContents.Length);
        }

        public byte[] FileContents { get; set; }
    }
}