using Bec.TargetFramework.WindowsService;
using Devart.Data.PostgreSql.Entity.Configuration;

namespace Bec.TargetFramework.Hosts.BusinessService
{
    static class Program
    {
        static void Main(string[] args)
        {
            PgSqlEntityProviderConfig.Instance.DmlOptions.InsertNullBehaviour = InsertNullBehaviour.InsertDefaultOrNull;
            WindowsServiceInitialiser<BusinessService>.InitialiseWindowsService(args);
        }
    }
}
