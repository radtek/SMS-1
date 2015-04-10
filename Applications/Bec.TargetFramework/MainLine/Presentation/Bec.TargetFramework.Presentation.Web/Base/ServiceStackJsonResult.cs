using System;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Text;

namespace Bec.TargetFramework.UI.Process.Base
{
    public class ServiceStackJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(this.ContentType) ? this.ContentType : "application/json";

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data != null)
            {
                response.Write(JsonSerializer.SerializeToString(this.Data));
            }
        }
    }
}