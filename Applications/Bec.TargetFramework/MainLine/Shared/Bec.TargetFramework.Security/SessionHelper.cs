using System.Configuration;
using System.Web;
using System.Web.Configuration;

namespace Bec.TargetFramework.Security
{
    public class SessionHelper
    {
        public static void SecureSession()
        {
             SessionStateSection sessionState =
 (SessionStateSection)ConfigurationManager.GetSection("system.web/sessionState");
        string sidCookieName = sessionState.CookieName;

        if (HttpContext.Current.Request.Cookies[sidCookieName] != null)
            {
                HttpCookie sidCookie = HttpContext.Current.Response.Cookies[sidCookieName];
                sidCookie.Value = HttpContext.Current.Session.SessionID;
                sidCookie.HttpOnly = true;
                sidCookie.Secure = true;
                sidCookie.Path = "/";
            }
        }

        public static void ClearSession()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session.RemoveAll();
            }
        }
    }
}