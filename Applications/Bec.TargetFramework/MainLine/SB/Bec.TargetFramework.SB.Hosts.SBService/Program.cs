using Bec.TargetFramework.WindowsService;

namespace Bec.TargetFramework.SB.Hosts.SBService
{
    static class Program
    {
        static void Main(string[] args)
        {
            WindowsServiceInitialiser<SBService>.InitialiseWindowsService(args);
        }
    }
}
