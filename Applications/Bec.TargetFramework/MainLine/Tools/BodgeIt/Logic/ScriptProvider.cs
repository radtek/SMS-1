using RestSharp;

namespace BodgeIt.Logic
{
    public class ScriptProvider
    {
        private const string BasePathFormat = "projects/BF/repos/main/browse/Applications/Bec.TargetFramework/MainLine/Bec.TargetFramework.DatabaseScripts/Scripts/{0}?raw";
        private const string StashUrl = "http://bec-dev-01:7990/";
        private const string Base64Pass = "Basic emVub25tOkJlY29uc3VsdGFuY3kj";

        public string GetScriptContent(string relativePath)
        {
            var client = new RestClient(StashUrl);
            var request = new RestRequest(string.Format(BasePathFormat, relativePath), Method.GET);

            request.AddHeader("Accept", "text/html");
            request.AddHeader("Authorization", Base64Pass);

            var response = client.Execute(request);
            var content = response.Content.TrimStart(new char[] { '\uFEFF' }); // raw content as string

            return content;
        }
    }
}
