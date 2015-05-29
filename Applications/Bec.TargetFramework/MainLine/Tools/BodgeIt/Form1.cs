using Devart.Data.PostgreSql;
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
            {0,"Host=bec-dev-01;User Id=postgres;Password=0277922cdd;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {1,"Host=sys-db-01;User Id=postgres;Password=Wzrfdza8VjM3y86WTqdX;Database=TargetFramework;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"}
        };

        Dictionary<int, string> coreCons = new Dictionary<int, string>(){
            {0,"Host=bec-dev-01;User Id=postgres;Password=0277922cdd;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"},
            {1,"Host=sys-db-01;User Id=postgres;Password=Wzrfdza8VjM3y86WTqdX;Database=TargetFrameworkCore;Port=5433;Persist Security Info=True;Initial Schema=public;Unicode=True;"}
        };

        public Form1()
        {
            InitializeComponent();

            comboType.DataSource = new [] { 
                new { Text = "User", Value = 1 },
                new { Text = "Administrator", Value = 2 },
                new { Text = "ComplianceOfficer", Value = 3 },
                new { Text = "Temporary", Value = 4 },
                new { Text = "BranchAdministrator", Value = 5 },
                new { Text = "OrganisationAdministrator", Value = 6 } 
            };
            comboType.DisplayMember = "Text";
            comboType.ValueMember = "Value";
            comboType.SelectedIndex = 1;            

            comboDB.DataSource = new[] { 
                new { Text = "bec-dev-01", Value = 0 },
                new { Text = "sys-db-01", Value = 1 }
            };
            comboDB.DisplayMember = "Text";
            comboDB.ValueMember = "Value";
            comboDB.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(comboAddress.Text) };
            await SendAsync<object>(client, string.Format("api/OrganisationLogic/ExpireOrganisations?days={0}&hours={1}&minutes={2}", numericUpDownDays.Value, numericUpDownHours.Value, numericUpDownMinutes.Value), HttpMethod.Post, "user", null);
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
            await SendAsync<object>(client, string.Format("api/OrganisationLogic/AddNewUserToOrganisation?organisationID={0}&userTypeValue={1}&username={2}&password={3}&isTemporary=false", new Guid(textOrgId.Text), comboType.SelectedValue, textUsername.Text, System.Net.WebUtility.UrlEncode(textPassword.Text)), HttpMethod.Post, "user", contact);
        }

        private async Task SendAsync<T>(HttpClient client, string requestUri, HttpMethod method, string user, T value)
        {
            var req = new HttpRequestMessage
            {
                RequestUri = new Uri(requestUri, UriKind.RelativeOrAbsolute),
                Method = method
            };
            if (value != null) req.Content = new ObjectContent<T>(value, new JsonMediaTypeFormatter(), (MediaTypeHeaderValue)null);
            if (user != null) req.Headers.Add("User", user);
            try
            {
                var x = await client.SendAsync(req);
                x.EnsureSuccessStatusCode();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "WARNING", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int conIndex = (int)comboDB.SelectedValue;
                using (PgSqlConnection con = new PgSqlConnection(tfCons[conIndex]))
                {
                    con.OpenAsync();
                    runScript(con, "truncate \"DefaultOrganisationTemplate\" cascade; truncate \"UserAccounts\" cascade; truncate \"StatusTypeTemplate\" cascade; truncate \"Operation\" cascade; truncate \"Resource\" cascade; truncate \"Role\" cascade; truncate \"NotificationConstructGroupTemplate\" cascade;");
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Security", "Security Categories.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Security", "Security.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Status.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Admin Organisation Template.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Admin Organisation Create.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Status.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Template.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Setup", "Organisation", "Professional", "Professional Organisation Create Default Organisation.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddCompanySystemAdminNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddUsernameReminderNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "AddForgotPasswordNotification.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "BE Framework Scripts", "Notifications", "PromoteNotifications.sql")));
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "Notification", "T&CNotificationsNoCOLP.sql")));
                    con.Close();
                }
                using (PgSqlConnection con = new PgSqlConnection(coreCons[conIndex]))
                {
                    con.OpenAsync();
                    runScript(con, "truncate \"BusEvent\" cascade; truncate \"BusEventMessageSubscriber\" cascade;");
                    runScript(con, File.ReadAllText(Path.Combine(baseDir, "Notification", "BusEvent.sql")));
                    con.Close();
                }
            }
            MessageBox.Show("Done");
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
                con.OpenAsync();
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
            MessageBox.Show("Done");
        }
    }
}
