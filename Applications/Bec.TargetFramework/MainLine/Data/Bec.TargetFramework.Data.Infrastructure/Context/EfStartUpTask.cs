using Bec.TargetFramework.Framework;
using Bec.TargetFramework.Framework.Data;
using Bec.TargetFramework.Framework.Infrastructure;

namespace Bec.TargetFramework.Data.Infrastructure.Context
{
    public class EfStartUpTask : IStartupTask
    {
        public void Execute()
        {
            var settings = EngineContext.Current.Resolve<DataSettings>();
            if (settings != null && settings.IsValid())
            {
                var provider = EngineContext.Current.Resolve<IDataProvider>();
                if (provider == null)
                    throw new TargetFrameworkException("No IDataProvider found");
                provider.SetDatabaseInitializer();
            }
        }

        public int Order
        {
            //ensure that this task is run first 
            get { return -1000; }
        }
    }
}
