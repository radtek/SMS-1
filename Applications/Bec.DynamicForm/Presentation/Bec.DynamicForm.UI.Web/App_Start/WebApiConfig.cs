using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Bec.TargetFramework.UI.Web
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new Elmah.Contrib.WebApi.ElmahHandleErrorApiAttribute());
        }
    }
}