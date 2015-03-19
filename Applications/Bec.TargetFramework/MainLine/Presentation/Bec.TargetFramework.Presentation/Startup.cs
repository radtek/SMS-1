using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.PostgreSql;
using Npgsql;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(Bec.TargetFramework.Presentation.Startup))]
namespace Bec.TargetFramework.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseHangfire(config =>
            {
                var sb  = new NpgsqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["HangFireConnectionString"].ConnectionString);

                sb.Pooling = false;

                var options = new PostgreSqlStorageOptions
                {
                    PrepareSchemaIfNecessary = true,
                    UseNativeDatabaseTransactions = true
                };
                
                config.UsePostgreSqlStorage(sb.ToString(),options);



                config.UseServer();
            });
        }
    }
}
