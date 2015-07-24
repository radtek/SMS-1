using Bec.TargetFramework.WindowsService;

namespace Bec.TargetFramework.SB.TaskServices
{
    static class Program
    {
        static void Main(string[] args)
        {
            WindowsServiceInitialiser<TaskService>.InitialiseWindowsService(args);
        }
    }
}
