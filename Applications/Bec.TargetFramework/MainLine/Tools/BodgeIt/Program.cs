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
            if (args.Any())
            {
                var consoleExecution = new ConsoleExecution();
                consoleExecution.Execute(args);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
