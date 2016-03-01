using Devart.Data.PostgreSql;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BodgeIt.Logic
{
    public class ScriptRunner
    {
        private readonly ScriptProvider _scriptProvider;
        public ScriptRunner()
        {
            _scriptProvider = new ScriptProvider();
        }

        public void CleanData(string tfConnectionString, string coreConnectionString)
        {
            using (PgSqlConnection con = new PgSqlConnection(tfConnectionString))
            {
                con.Open();
                RunScript(con, "truncate \"DefaultOrganisationTemplate\" cascade; truncate \"UserAccounts\" cascade; truncate \"StatusTypeTemplate\" cascade; truncate \"Operation\" cascade; truncate \"Resource\" cascade; truncate \"Role\" cascade; truncate \"NotificationConstructGroupTemplate\" cascade; delete from \"ContactRegulator\"; delete from \"Contact\"; delete from \"Address\"; truncate table \"ProductTemplate\" cascade;");
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Security", "Security Categories.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Security", "Security.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Organisation", "Status.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Organisation", "Admin Organisation Template.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Organisation", "Admin Organisation Create.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Status.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Template.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Create Default Organisation.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Organisation", "Personal", "Personal Organisation Template.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Setup", "Organisation", "Personal", "Personal Organisation Create Default Organisation.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "AddCompanySystemAdminNotification.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "AddUserNotification.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "AddUsernameReminderNotification.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "AddForgotPasswordNotification.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "AddBankAccountMarkedAsFraudSuspiciousNotification.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "AddBankAccountMarkedAsSafeNotification.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "AddCreditAdjustmentNotification.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "AddNewInternalMessagesNotification.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "Notifications", "PromoteNotifications.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("BE Framework Scripts", "ProductInitial.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("Creation Scripts", "Product", "CreditTopUp.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("Creation Scripts", "Product", "Bank Account Check.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("Creation Scripts", "Product", "PromoteProduct.sql")));
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("Notification", "T&CNotificationsNoCOLP.sql")));

                con.Close();
            }
            using (PgSqlConnection con = new PgSqlConnection(coreConnectionString))
            {
                con.Open();
                RunScript(con, "truncate \"BusEvent\" cascade; truncate \"BusEventMessageSubscriber\" cascade;");
                RunScript(con, _scriptProvider.GetScriptContent(Path.Combine("Notification", "BusEvent.sql")));
                con.Close();
            }
        }

        public async Task AddSallyUser(Guid orgID, string server, string lastName, string email, string password)
        {
            var contact = new
            {
                FirstName = "Admin",
                LastName = lastName,
                EmailAddress1 = email,
                Salutation = "Mr"
            };
            HttpClient client = new HttpClient { BaseAddress = new Uri(server) };
            var x = await SendAsync<object>(client, string.Format("api/OrganisationLogic/AddNewUserToOrganisationAsync?organisationID={0}&userTypeValue=Administrator&addDefaultRoles=true",
                orgID), HttpMethod.Post, "user", contact);
            var s = await x.Content.ReadAsStringAsync();
            Guid uaoId = (Guid)JObject.Parse(s)["UserAccountOrganisationID"];

            await SendAsync<object>(client, string.Format("api/UserLogic/RegisterUserAsync?uaoId={0}&password={1}&phoneNumber=0777777",
                uaoId, WebUtility.UrlEncode(password)), HttpMethod.Post, "user", null);
        }

        public Guid GetCurrentOrganisationId(string connectionString)
        {
            using (PgSqlConnection con = new PgSqlConnection(connectionString))
            {
                var result = new Guid();

                con.Open();
                var c = con.CreateCommand();
                c.CommandText = "select \"OrganisationID\" from \"Organisation\" limit 1";
                using (var r = c.ExecuteReader())
                {
                    while (r.Read())
                    {
                        result = r.GetGuid(0);
                    }
                }
                con.Close();

                return result;
            }
        }

        public void RunScript(PgSqlConnection connection, string text)
        {
            var c = connection.CreateCommand();
            c.CommandText = text;
            c.UnpreparedExecute = true;
            c.ExecuteReader();
        }

        private async Task<HttpResponseMessage> SendAsync<T>(HttpClient client, string requestUri, HttpMethod method, string user, T value)
            where T : class
        {
            var req = new HttpRequestMessage
            {
                RequestUri = new Uri(requestUri, UriKind.RelativeOrAbsolute),
                Method = method
            };
            if (value != null) req.Content = new ObjectContent<T>(value, new JsonMediaTypeFormatter(), (MediaTypeHeaderValue)null);
            if (user != null) req.Headers.Add("User", user);
            var x = await client.SendAsync(req);
            return x;
        }
    }
}
