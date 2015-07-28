using Bec.TargetFramework.WindowsService;

namespace Bec.TargetFramework.Hosts.BusinessService
{
    static class Program
    {
        static void Main(string[] args)
        {
            WindowsServiceInitialiser<BusinessService>.InitialiseWindowsService(args);
        }
    }
}
