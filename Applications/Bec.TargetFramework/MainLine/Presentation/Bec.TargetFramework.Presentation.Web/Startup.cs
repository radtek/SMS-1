using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.PostgreSql;
using Npgsql;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(Bec.TargetFramework.Presentation.Web.Startup))]
namespace Bec.TargetFramework.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseHangfire(config =>
            //{
            //    var sb = new NpgsqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["HangFireConnectionString"].ConnectionString);

            //    sb.Pooling = true;

            //    var options = new PostgreSqlStorageOptions
            //    {
            //        PrepareSchemaIfNecessary = true,
            //        UseNativeDatabaseTransactions = true
            //    };

            //    config.UsePostgreSqlStorage(sb.ToString(), options);

            //    config.UseServer();
            //});
        }
    }
}
