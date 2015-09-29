using BodgeIt.Logic;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace BodgeIt
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Any(a => a.Contains("CleanData")))
            {
                var tfConnectionString = ConfigurationManager.ConnectionStrings["TargetFrameworkConnectionString"].ConnectionString;
                var coreConnectionString = ConfigurationManager.ConnectionStrings["TargetFrameworkCoreConnectionString"].ConnectionString;
                var server = ConfigurationManager.AppSettings["BusinessServiceBaseURL"];
                var scriptRunner = new ScriptRunner();

                scriptRunner.CleanData(tfConnectionString, coreConnectionString);
                var orgID = scriptRunner.GetCurrentOrganisationId(tfConnectionString);
                var task = scriptRunner.AddSallyUser(orgID, server, "T1", "applications@beconsultancy.co.uk", "Registration#");
                task.Wait();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
