using Bec.TargetFramework.Data;
using Bec.TargetFramework.SB.Data;
using Devart.Data.PostgreSql;
using Mehdime.Entity;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace Bec.TargetFramework.TestsService.Controllers
{
    public class ManagementController : ApiController
    {
        private const string _baseDir = @"C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Bec.TargetFramework.DatabaseScripts\Scripts";
        public IDbContextScopeFactory DbContextScopeFactory { get; set; }

        public async Task<bool> CleanData()
        {
            string tfConnectionString;
            string coreConnectionString;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                tfConnectionString = scope.DbContexts.Get<TargetFrameworkEntities>().Database.Connection.ConnectionString;
                coreConnectionString = scope.DbContexts.Get<TargetFrameworkCoreEntities>().Database.Connection.ConnectionString;
            }

            var result = false;
            using (PgSqlConnection con = new PgSqlConnection(tfConnectionString))
            {
                con.Open();
                runScript(con, "truncate \"DefaultOrganisationTemplate\" cascade; truncate \"UserAccounts\" cascade; truncate \"StatusTypeTemplate\" cascade; truncate \"Operation\" cascade; truncate \"Resource\" cascade; truncate \"Role\" cascade; truncate \"NotificationConstructGroupTemplate\" cascade; delete from \"ContactRegulator\"; delete from \"Contact\"; delete from \"Address\"; truncate table \"ProductTemplate\" cascade;");
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Security", "Security Categories.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Security", "Security.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Organisation", "Status.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Organisation", "Admin Organisation Template.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Organisation", "Admin Organisation Create.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Status.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Template.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Create Default Organisation.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Organisation", "Personal", "Personal Organisation Template.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Setup", "Organisation", "Personal", "Personal Organisation Create Default Organisation.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Notifications", "AddCompanySystemAdminNotification.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Notifications", "AddUserNotification.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Notifications", "AddUsernameReminderNotification.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Notifications", "AddForgotPasswordNotification.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Notifications", "AddBankAccountMarkedAsFraudSuspiciousNotification.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Notifications", "AddBankAccountMarkedAsSafeNotification.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Notifications", "AddCreditAdjustmentNotification.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "Notifications", "PromoteNotifications.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "BE Framework Scripts", "ProductInitial.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "Creation Scripts", "Product", "CreditTopUp.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "Creation Scripts", "Product", "Bank Account Check.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "Creation Scripts", "Product", "PromoteProduct.sql")));
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "Notification", "T&CNotificationsNoCOLP.sql")));
                con.Close();
            }
            using (PgSqlConnection con = new PgSqlConnection(coreConnectionString))
            {
                con.Open();
                runScript(con, "truncate \"BusEvent\" cascade; truncate \"BusEventMessageSubscriber\" cascade;");
                runScript(con, File.ReadAllText(Path.Combine(_baseDir, "Notification", "BusEvent.sql")));
                con.Close();

                result = true;
            }

            return result;
        }

        private void runScript(PgSqlConnection connection, string text)
        {
            var c = connection.CreateCommand();
            c.CommandText = text;
            c.UnpreparedExecute = true;
            c.ExecuteReader();
        }
    }
}
