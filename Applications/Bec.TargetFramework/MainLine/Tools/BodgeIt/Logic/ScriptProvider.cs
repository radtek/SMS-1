using Atlassian.Stash.Api;
using System;
using System.IO;
using System.Linq;

namespace BodgeIt.Logic
{
    public class ScriptProvider
    {
        private const string BasePath = "Applications/Bec.TargetFramework/MainLine/Bec.TargetFramework.DatabaseScripts/Scripts/";
        private const string StashUrl = "http://bec-dev-01:7990/";
        private const string Base64Pass = "emVub25tOkJlY29uc3VsdGFuY3kj";
        private const string ProjectKey = "BF";
        private const string RepositorySlug = "Main";

        public string GetScriptContent(string relativePath)
        {
            var client = new StashClient(StashUrl, Base64Pass);

            var filePath = Path.Combine(BasePath, relativePath);
            filePath.Replace(" ", "%20");

            var fileContents = client.Repositories.GetFileContents(ProjectKey, RepositorySlug, filePath, new Atlassian.Stash.Api.Helpers.RequestOptions { Limit = short.MaxValue - 1 }).Result;

            return string.Join(Environment.NewLine, fileContents.FileContents
                .Select((s, i) => {
                    if (i == 0)
                    {
                        return s.TrimStart(new char[] { '\uFEFF' }); // remove BOM
                    }
                    else
                    {
                        return s;
                    }
                })); 
        }
    }
}
