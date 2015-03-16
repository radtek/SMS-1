using Bec.TargetFramework.Framework;
using Bec.TargetFramework.Framework.Data;
using System;

namespace Bec.TargetFramework.Data.Infrastructure.Context
{
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings settings):base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {

            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new TargetFrameworkException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                default:
                    throw new TargetFrameworkException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

    }
}
