#region Using

using Bec.TargetFramework.Presentation.Web.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


#endregion

namespace Bec.TargetFramework.Presentation.Web
{
    public class CaptchaService
    {
        HttpClient httpClient;
        public CaptchaService()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://www.google.com/recaptcha/api/") };
        }
        public async Task<CaptchaResponse> ValidateCaptcha(HttpRequestBase request)
        {
            string g_recaptcha_response = request["g-recaptcha-response"];
            var remote_ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
            var gr = await httpClient.PostAsync("siteverify?secret=6LfblQcTAAAAAFCb0kLLPOhJnU8YgwrjIjw-XVNI&response=" + g_recaptcha_response + "&remoteip=" + remote_ip, null);
            gr.EnsureSuccessStatusCode();
            var response = await gr.Content.ReadAsAsync<CaptchaResponse>();
            return response;
        }
    }
}