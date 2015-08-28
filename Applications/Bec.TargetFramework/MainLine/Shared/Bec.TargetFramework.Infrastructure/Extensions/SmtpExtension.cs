using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace System.NET
{
    public class SmtpExtension : SmtpClient
    {
        /// <summary>
        /// Overrides Sending of emails when in different environments
        /// </summary>
        /// <param name="message"></param>
        public void SendEmailAsync(MailMessage message,string userState)
        {
            bool overrideEmail = false;

            if (ConfigurationManager.AppSettings["OverrideEmail"] != null)
            {
                bool.TryParse(ConfigurationManager.AppSettings["OverrideEmail"], out overrideEmail);

                if (overrideEmail)
                {
                    if (ConfigurationManager.AppSettings["OverrideEmailToAddresses"] == null)
                        throw new KeyNotFoundException("OverrideEmailToAddresses appSetting cannot be found, if OverrideEmail=true then this appSetting needs to be present");

                    // split by semi colon
                    string[] addresses = ConfigurationManager.AppSettings["OverrideEmailToAddresses"].Split(';');

                    string from = ConfigurationManager.AppSettings["OverrideEmailFromAddress"];

                    message.Body = message.Body + ": Emails To";

                    message.To.OfType<MailAddress>().ToList().ForEach(item => message.Body += item + ",");

                    message.Body = message.Body + ": Emails Bcc";

                    message.Bcc.OfType<MailAddress>().ToList().ForEach(item => message.Body += item + ",");

                    message.Body = message.Body + ": Emails From";

                    message.Body = message.Body + ": Emails From" + message.From;

                    message.Bcc.Clear();
                    message.To.Clear();
                    message.CC.Clear();
                    message.From = new MailAddress(from);

                    foreach (string address in addresses)
                    {
                        message.To.Add(new MailAddress(address));
                    }
                    
                    SendAsync(message, userState);
                }
            }
            else
                SendAsync(message, userState);
        }
    }
}
