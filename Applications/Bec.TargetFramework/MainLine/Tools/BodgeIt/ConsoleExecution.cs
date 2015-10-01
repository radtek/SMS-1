using BodgeIt.Logic;
using System.Configuration;
using System.Linq;

namespace BodgeIt
{
    public class ConsoleExecution
    {
        public void Execute(string[] args)
        {
            if (args.Any(a => a.Contains("CleanData")))
            {
                CleanDataAndAddSally(args);
            }
        }

        private void CleanDataAndAddSally(string[] args)
        {
            var connectionPrefix = GetConnectionPrefix(args);
            var tfConnectionString = ConfigurationManager.ConnectionStrings[connectionPrefix + "TargetFrameworkConnectionString"].ConnectionString;
            var coreConnectionString = ConfigurationManager.ConnectionStrings[connectionPrefix + "TargetFrameworkCoreConnectionString"].ConnectionString;
            var server = ConfigurationManager.AppSettings[connectionPrefix + "BusinessServiceBaseURL"];

            var scriptRunner = new ScriptRunner();

            scriptRunner.CleanData(tfConnectionString, coreConnectionString);
            var orgID = scriptRunner.GetCurrentOrganisationId(tfConnectionString);
            var task = scriptRunner.AddSallyUser(orgID, server, "T1", "applications@beconsultancy.co.uk", "Registration#");
            task.Wait();
        }

        private string GetConnectionPrefix(string[] args)
        {
            const string dev = "Dev";
            const string sys = "Sys";
            const string uat = "Uat";

            var result = "Local";
            if (args.Any(a => a.Contains(dev)))
            {
                result = dev;
            }
            else if (args.Any(a => a.Contains(sys)))
            {
                result = sys;
            }
            else if (args.Any(a => a.Contains(uat)))
            {
                result = uat;
            }

            return result;
        }
    }
}
