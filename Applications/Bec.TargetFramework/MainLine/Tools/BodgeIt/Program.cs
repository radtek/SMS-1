using BodgeIt.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodgeIt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Any(a => a.Contains("CleanData")))
            {
                var tfConnectionString = Constants.TfCons[0];
                var coreConnectionString = Constants.CoreCons[0];
                var server = Constants.Servers[0];
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
