#region Using

using Bec.TargetFramework.Presentation.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


#endregion

namespace Bec.TargetFramework.Presentation.Web
{
    public class CaptchaService
    {
        readonly HttpClient httpClient;
        public CaptchaService()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://www.google.com/recaptcha/api/") };
        }
        public async Task<CaptchaResponse> ValidateCaptcha(HttpRequestBase request)
        {
            string g_recaptcha_response = request["g-recaptcha-response"];
            var remote_ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("response", g_recaptcha_response));
            HttpContent content = new FormUrlEncodedContent(postData);

            var gr = await httpClient.PostAsync("siteverify?secret=6LfblQcTAAAAAFCb0kLLPOhJnU8YgwrjIjw-XVNI&remoteip=" + remote_ip, content);
            gr.EnsureSuccessStatusCode();
            var response = await gr.Content.ReadAsAsync<CaptchaResponse>();
            return response;
        }
    }
}