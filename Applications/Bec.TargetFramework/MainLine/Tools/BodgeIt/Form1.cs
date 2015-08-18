using BodgeIt.TestDTOs;
using Devart.Data.PostgreSql;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodgeIt
{
    public partial class Form1 : Form
    {
        const string baseDir = @"C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Bec.TargetFramework.DatabaseScripts\Scripts";
        Dictionary<int, string> tfCons = new Dictionary<int,string>(){
            {0,"Host=localhost;User Id=postgres;Password=admin;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {1,"Host=bec-dev-01;User Id=postgres;Password=0277922cdd;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {2,"Host=sys-db-01;User Id=postgres;Password=Wzrfdza8VjM3y86WTqdX;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"}
        };

        Dictionary<int, string> coreCons = new Dictionary<int, string>(){
            {0,"Host=localhost;User Id=postgres;Password=admin;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {1,"Host=bec-dev-01;User Id=postgres;Password=0277922cdd;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {2,"Host=sys-db-01;User Id=postgres;Password=Wzrfdza8VjM3y86WTqdX;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"}
        };

        public Form1()
        {
            InitializeComponent();        

            comboDB.DataSource = new[] { 
                new { Text = "localhost", Value = 0 },
                new { Text = "bec-dev-01", Value = 1 },
                new { Text = "sys-db-01", Value = 2 }
            };
            comboDB.DisplayMember = "Text";
            comboDB.ValueMember = "Value";
            comboDB.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(comboAddress.Text) };
            await SendAsync<object>(client, string.Format("api/OrganisationLogic/ExpireTemporaryLoginsAsync?days={0}&hours={1}&minutes={2}", numericUpDownDays.Value, numericUpDownHours.Value, numericUpDownMinutes.Value), HttpMethod.Post, "user", null);
            MessageBox.Show("Done");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var contact = new {
                FirstName = textFirstName.Text,
                LastName = textLastName.Text,
                EmailAddress1 = textEmail.Text,
                Salutation = textSalutation.Text
            };
            HttpClient client = new HttpClient { BaseAddress = new Uri(comboAddress.Text) };
            await SendAsync<object>(client, string.Format("api/OrganisationLogic/AddNewUserToOrganisationAsync?organisationID={0}&username={1}&password={2}&isTemporary=false&sendEmail=false", new Guid(textOrgId.Text), textUsername.Text, System.Net.WebUtility.UrlEncode(textPassword.Text)), HttpMethod.Post, "user", contact);
            MessageBox.Show("Done");
        }

        private async Task<HttpResponseMessage> SendAsync<T>(HttpClient client, string requestUri, HttpMethod method, string user, T value)
        {
            var req = new HttpRequestMessage
            {
                RequestUri = new Uri(requestUri, UriKind.RelativeOrAbsolute),
                Method = method
            };
            if (value != null) req.Content = new ObjectContent<T>(value, new JsonMediaTypeFormatter(), (MediaTypeHeaderValue)null);
            if (user != null) req.Headers.Add("User", user);
            //try
            //{
            //    var x = await client.SendAsync(req);
            //    x.EnsureSuccessStatusCode();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
                var x = await client.SendAsync(req);
           // x.EnsureSuccessStatusCode();
            return x;
            }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "WARNING", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int conIndex = (int)comboDB.SelectedValue;
                using (PgSqlConnection con = new PgSqlConnection(tfCons[conIndex]))
                {
                    con.Open();
                    runScript(con, "truncate \"DefaultOrganisationTemplate\" cascade; truncate \"UserAccounts\" cascade; truncate \"StatusTypeTemplate\" cascade; truncate \"Operation\" cascade; truncate \"Resource\" cascade; truncate \"Role\" cascade; truncate \"NotificationConstructGroupTemplate\" cascade; delete from \"ContactRegulator\"; delete from \"Contact\"; delete from \"Address\"; truncate table \"ProductTemplate\" cascade;");
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Security", "Security Categories.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Security", "Security.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Status.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Admin Organisation Template.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Admin Organisation Create.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Status.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Template.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Create Default Organisation.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddCompanySystemAdminNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddUserNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddUsernameReminderNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddForgotPasswordNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddBankAccountMarkedAsFraudSuspiciousNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddBankAccountMarkedAsSafeNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "PromoteNotifications.sql")));                 
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "ProductInitial.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "Creation Scripts", "Product", "CreditTopUp.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "Creation Scripts", "Product", "PromoteProduct.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "Notification", "T&CNotificationsNoCOLP.sql")));
                    con.Close();
                }
                using (PgSqlConnection con = new PgSqlConnection(coreCons[conIndex]))
                {
                    con.Open();
                    runScript(con, "truncate \"BusEvent\" cascade; truncate \"BusEventMessageSubscriber\" cascade;");
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "Notification", "BusEvent.sql")));
                    con.Close();
                }
            }
        }

        private void runScript(PgSqlConnection connection, string text)
        {
            var c = connection.CreateCommand();
            c.CommandText = text;
            c.UnpreparedExecute = true;
            c.ExecuteReader();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int conIndex = (int)comboDB.SelectedValue;
            using (PgSqlConnection con = new PgSqlConnection(tfCons[conIndex]))
            {
                con.Open();
                var c = con.CreateCommand();
                c.CommandText = "select \"OrganisationID\" from \"Organisation\" limit 1";
                using (var r = c.ExecuteReader())
                {
                    while (r.Read())
                    {
                        textOrgId.Text = r.GetGuid(0).ToString();
                    }
                }
                con.Close();
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK) textReportFilename.Text = fd.FileName;
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            byte[] bytes = File.ReadAllBytes(textReportFilename.Text);
            List<Guid> uaos = new List<Guid>();

            //update latest notification construct
            int conIndex = (int)comboDB.SelectedValue;
            using (PgSqlConnection con = new PgSqlConnection(tfCons[conIndex]))
            {
                await con.OpenAsync();
                var c = con.CreateCommand();
                c.CommandText = string.Format("select \"NotificationConstructID\" from \"NotificationConstruct\" where \"Name\" = '{0}' limit 1", textNCName.Text);
                Guid id = (Guid)await c.ExecuteScalarAsync();

                c.CommandText = string.Format("select max(\"NotificationConstructVersionNumber\") from \"NotificationConstruct\" where \"NotificationConstructID\" = '{0}' limit 1", id);
                int version = (int)await c.ExecuteScalarAsync();
                
                c.CommandText = string.Format("update \"NotificationConstructData\" set \"NotificationData\" = @p1 where \"NotificationConstructID\" = '{0}' and \"NotificationConstructVersionNumber\" = {1} ", id, version);
                c.Parameters.AddWithValue("@p1", bytes);
                await c.ExecuteNonQueryAsync();

                c.Parameters.Clear();
                c.CommandText = "select \"UserAccountOrganisationID\" from \"UserAccountOrganisation\" uao join \"UserType\" uat on uat.\"UserTypeID\" =  uao.\"UserTypeID\" where uat.\"Name\" = 'Organisation Administrator'";
                using (var r = await c.ExecuteReaderAsync())
                {
                    while (await r.ReadAsync()) uaos.Add(r.GetGuid(0));
                }

                con.Close();
            }

            //insert new notifications for permanent users
            HttpClient client = new HttpClient { BaseAddress = new Uri(comboAddress.Text) };
            foreach (var id in uaos) await SendAsync<object>(client, string.Format("api/OrganisationLogic/CreateTsAndCsNotificationAsync?userOrgID={0}", id), HttpMethod.Post, "user", null);
            MessageBox.Show("Done");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int conIndex = (int)comboDB.SelectedValue;
            using (PgSqlConnection con = new PgSqlConnection(tfCons[conIndex]))
            {
                con.Open();
                runScript(con, File.ReadAllText(Path.Combine(baseDir, "Notification", "NewT&CNotification.sql")));
                con.Close();
            }
            MessageBox.Show("Done");
        }

        private async void buttonAutoAdmin_Click(object sender, EventArgs e)
        {
            button4_Click(this, null);

            Guid orgID = new Guid(textOrgId.Text);

            for (int i = 1; i < 6; i++)
            {
                var contact = new
                {
                    FirstName = "Admin",
                    LastName = "T" + i.ToString(),
                    EmailAddress1 = textEmail.Text,
                    Salutation = textSalutation.Text
                };
                HttpClient client = new HttpClient { BaseAddress = new Uri(comboAddress.Text) };
                var x = await SendAsync<object>(client, string.Format("api/OrganisationLogic/AddNewUserToOrganisationAsync?organisationID={0}&userTypeValue=Administrator&username={1}&password={2}&isTemporary=false&sendEmail=false&addDefaultRoles=true", orgID, "T" + i.ToString(), System.Net.WebUtility.UrlEncode(textPassword.Text)), HttpMethod.Post, "user", contact);
                var s = await x.Content.ReadAsStringAsync();
                Guid g = (Guid)JObject.Parse(s)["UserAccountOrganisationID"];

                //apply all available roles

                //var y = await SendAsync<Guid[]>(client, string.Format("api/OrganisationLogic/GetRoles?orgID={0}", orgID), HttpMethod.Get, "user", null);
                //var t = await y.Content.ReadAsStringAsync();
                //Guid[] roles = JArray.Parse(t).Select(j => (Guid)j["OrganisationRoleID"]).ToArray();

                //await SendAsync<Guid[]>(client, string.Format("api/UserLogic/SetRolesAsync?uaoID={0}", g), HttpMethod.Post, "user", roles);
            }
            MessageBox.Show("Done");
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(comboAddress.Text) };
            //var r = await SendAsync<object>(client, string.Format("api/OrganisationLogic/GetUsers?$select=UserID,NickName&$expand=Contact($select=Salutation,FirstName,LastName)"), HttpMethod.Get, "user", null);
            //var r = await SendAsync<object>(client, string.Format("api/QueryLogic/Get/SmsTransactions?$select=Reference,CreatedOn&$expand=Address($select=Line1,PostalCode)"), HttpMethod.Get, "user", null);
            //var r = await SendAsync<object>(client, string.Format("odata/test(Id='SmsTransactions')?$select=Reference&$count=true"), HttpMethod.Get, "user", null);
            //var r = await SendAsync<object>(client, string.Format("odata/GetSalesTaxRate(PostalCode=10)"), HttpMethod.Get, "user", null);
            //var r = await SendAsync<object>(client, string.Format("odata/test(Id='SmsTransactions')"), HttpMethod.Get, "user", null);

            //var r = await SendAsync<object>(client, string.Format("api/QueryLogic/Get/SmsTransactions?$select=Reference&$count=true&$top=3&$skip=0"), HttpMethod.Get, "user", null);
            //var r = await SendAsync<object>(client, string.Format("api/QueryLogic/Get/SmsTransactions?$select=Reference&$count=true"), HttpMethod.Get, "user", null);
            //var r = await SendAsync<object>(client, string.Format("api/QueryLogic/Get/SmsTransactions?$count=true"), HttpMethod.Get, "user", null);

            //var r = await SendAsync<object>(client, string.Format("api/QueryLogic/Get/OrganisationBankAccounts?$select=OrganisationBankAccountID&$expand=OrganisationBankAccountStatus($select=StatusChangedBy,StatusChangedOn,Notes,WasActive;$expand=StatusTypeValue($select=Name,Description))"), HttpMethod.Get, "user", null);

            //var select = ODataHelper.Select<OrganisationBankAccountDTO>(x => new
            //{
            //    x.OrganisationBankAccountID,
            //    x.BankAccountNumber,
            //    x.SortCode,
            //    x.Created,
            //    a = x.OrganisationBankAccountStatus.Select(status => new
            //    {
            //        status.StatusChangedBy,
            //        status.StatusChangedOn,
            //        status.Notes,
            //        status.WasActive,
            //        status.StatusTypeValue.Name
            //    })
            //});
            //var filter = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.OrganisationID == orgID);

            //var r = await SendAsync<object>(client, string.Format("api/QueryLogic/Get/OrganisationBankAccounts?" + select), HttpMethod.Get, "user", null);

            var r = await SendAsync<object>(client, string.Format("api/QueryLogic/Get/OrganisationLedgerTransactions?&$select=Balance,BalanceOn&$expand=TransactionOrder($expand=Invoice($select=InvoiceReference))&$filter=(((BalanceOn ge 2014-08-02) and (BalanceOn le 2015-08-03)) and (OrganisationLedgerAccount/OrganisationID eq 2b96ba92-3796-11e5-8c84-00155d0a1473))"), HttpMethod.Get, "user", null);
            
            var s = await r.Content.ReadAsStringAsync();
            JObject j = JObject.Parse(s);
            MessageBox.Show(r.StatusCode + Environment.NewLine + j.ToString());
        }

    }
}
