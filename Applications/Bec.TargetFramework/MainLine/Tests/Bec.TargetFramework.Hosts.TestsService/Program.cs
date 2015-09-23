using Bec.TargetFramework.WindowsService;
using Devart.Data.PostgreSql.Entity.Configuration;

namespace Bec.TargetFramework.Hosts.TestsService
{
    static class Program
    {
        static void Main(string[] args)
        {
            PgSqlEntityProviderConfig.Instance.DmlOptions.InsertNullBehaviour = InsertNullBehaviour.InsertDefaultOrNull;
            WindowsServiceInitialiser<TestsService>.InitialiseWindowsService(args);
        }
    }
}
