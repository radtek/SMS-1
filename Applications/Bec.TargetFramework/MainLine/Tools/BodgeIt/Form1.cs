using BodgeIt.Logic;
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
using System.Xml;

namespace BodgeIt
{
    public partial class Form1 : Form
    {
        private readonly ScriptRunner _scriptRunner;
        public Form1()
        {
            InitializeComponent();        

            comboDB.DataSource = new[] { 
                new { Text = "localhost", Value = 0 },
                new { Text = "bec-dev-01", Value = 1 },
                new { Text = "sys-db-01", Value = 2 },
                new { Text = "uat-db-01", Value = 3 }
            };
            comboDB.DisplayMember = "Text";
            comboDB.ValueMember = "Value";
            comboDB.SelectedIndex = 0;

            comboBox1.SelectedIndex = 0;
            _scriptRunner = new ScriptRunner();
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
                _scriptRunner.CleanData(Constants.TfCons[conIndex], Constants.CoreCons[conIndex]);
            }
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            int conIndex = (int)comboDB.SelectedValue;
            textOrgId.Text = _scriptRunner.GetCurrentOrganisationId(Constants.TfCons[conIndex]).ToString();
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
            using (PgSqlConnection con = new PgSqlConnection(Constants.TfCons[conIndex]))
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
                c.CommandText = string.Format("select \"UserAccountOrganisationID\" from \"UserAccountOrganisation\" uao join \"UserType\" uat on uat.\"UserTypeID\" =  uao.\"UserTypeID\" where uat.\"Name\" = '{0}'", comboBox1.Text);
                using (var r = await c.ExecuteReaderAsync())
                {
                    while (await r.ReadAsync()) uaos.Add(r.GetGuid(0));
                }

                con.Close();
            }

            //insert new notifications for permanent users
            HttpClient client = new HttpClient { BaseAddress = new Uri(comboAddress.Text) };
            foreach (var id in uaos)
            {
                var x = await SendAsync<object>(client, string.Format("api/OrganisationLogic/CreateTsAndCsNotificationAsync?userOrgID={0}&type={1}", id, textNCName.Text), HttpMethod.Post, "user", null);
                x.EnsureSuccessStatusCode();
            }
            MessageBox.Show("Done");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int conIndex = (int)comboDB.SelectedValue;
            using (PgSqlConnection con = new PgSqlConnection(Constants.TfCons[conIndex]))
            {
                con.Open();
                _scriptRunner.RunScript(con, File.ReadAllText(Path.Combine(Constants.BaseDir, "Notification", "NewT&CNotification.sql")));
                con.Close();
            }
            MessageBox.Show("Done");
        }

        private async void buttonAutoAdmin_Click(object sender, EventArgs e)
        {
            button4_Click(this, null);

            Guid orgID = new Guid(textOrgId.Text);
            for (int i = 1; i <= numericUpDown1.Value; i++)
            {
                await _scriptRunner.AddSallyUser(orgID, comboAddress.Text, "T" + i.ToString(), string.Format(textEmail.Text, i), textPassword.Text);
            }
            MessageBox.Show("Users T1-T5 added successfully!");
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

        private async void addDefaultUsers_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add default organisation and users?", "WARNING", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                buttonAutoAdmin_Click(this, null);
                int conIndex = (int)comboDB.SelectedValue;
                using (PgSqlConnection con = new PgSqlConnection(Constants.TfCons[conIndex]))
                {
                    con.Open();
                    _scriptRunner.RunScript(con, File.ReadAllText(Path.Combine(Constants.BaseDir, "BE Framework Scripts", "Setup", "Defaults", "AddDefaultProOrganisationWithUsers.sql")));
                    _scriptRunner.RunScript(con, File.ReadAllText(Path.Combine(Constants.BaseDir, "BE Framework Scripts", "Setup", "Defaults", "AddDefaultFred.sql")));
                    con.Close();
                }
                MessageBox.Show("Ana, Elvis1, Elvis2 and Fred were added successfully! Wait for the rest.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\poc\select.xml");
            foreach (XmlNode n in doc.SelectNodes("/select/option"))
                sb.AppendLine(string.Format("insert into \"Lender\"(\"Name\") values ('{0}');", n.InnerText.Replace("'", "''")));

            int conIndex = (int)comboDB.SelectedValue;
            using (PgSqlConnection con = new PgSqlConnection(Constants.TfCons[conIndex]))
            {
                con.Open();
                _scriptRunner.RunScript(con, sb.ToString());
                con.Close();
            }
        }

        private async void buttonInvite_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(comboAddress.Text) };

            int conIndex = (int)comboDB.SelectedValue;
            using (PgSqlConnection con = new PgSqlConnection(Constants.TfCons[conIndex]))
            {
                con.Open();
                //first move any accounts with the given email address to one side
                _scriptRunner.RunScript(con, string.Format("update \"UserAccounts\" set \"Email\" = concat(\"Email\" , random()) where \"Email\" = '{0}'", textBoxInviteEmail.Text));
                //change user's email address
                _scriptRunner.RunScript(con, string.Format("update \"UserAccounts\" set \"Email\" = '{0}' where\"Username\" = '{1}'", textBoxInviteEmail.Text, textBoxInviteUsername.Text));
                con.Close();
            }

            //post password reset request
            var r = await SendAsync<object>(client, string.Format("api/UserLogic/SendPasswordResetNotificationAsync?username={0}&siteUrl={1}", textBoxInviteUsername.Text, "/Account/Forgot/Reset?resetId={0}&expire={1}"), HttpMethod.Post, "user", null);
            var s = await r.Content.ReadAsStringAsync();
        }
    }
}
