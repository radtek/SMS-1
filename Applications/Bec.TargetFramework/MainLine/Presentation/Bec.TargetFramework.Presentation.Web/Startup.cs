using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.PostgreSql;
using Npgsql;
using System.Configuration;
using ServiceStack.Text;

[assembly: OwinStartupAttribute(typeof(Bec.TargetFramework.Presentation.Web.Startup))]
namespace Bec.TargetFramework.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JsConfig.DateHandler = JsonDateHandler.ISO8601;
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
