using RestSharp;
using System.Configuration;

namespace BodgeIt.Logic
{
    public class ScriptProvider
    {
        public string GetScriptContent(string relativePath)
        {
            var basePathFormat = ConfigurationManager.AppSettings["StashSqlBasePathFormat"];
            var stashUrl = ConfigurationManager.AppSettings["StashUrl"];
            var stashBase64Pass = ConfigurationManager.AppSettings["StashBase64Pass"];

            var client = new RestClient(stashUrl);
            var request = new RestRequest(string.Format(basePathFormat, relativePath), Method.GET);

            request.AddHeader("Accept", "text/html");
            request.AddHeader("Authorization", stashBase64Pass);

            var response = client.Execute(request);
            var content = response.Content.TrimStart(new char[] { '\uFEFF' }); // raw content as string

            return content;
        }
    }
}
