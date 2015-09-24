using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Helpers
{
    public static class SmtpHelper
    {
        public static void Send(MailMessage message)
        {
            int port = 25;
            bool ssl = false;
            message.From = new MailAddress(ConfigurationManager.AppSettings["smtp:from"]);
            string host = ConfigurationManager.AppSettings["smtp:host"];
            int.TryParse(ConfigurationManager.AppSettings["smtp:port"], out port);            
            bool.TryParse(ConfigurationManager.AppSettings["smtp:ssl"], out ssl);

            using (SmtpClient smtpClient = new SmtpClient(host, port))
            {
                smtpClient.EnableSsl = ssl;
                smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["smtp:user"], ConfigurationManager.AppSettings["smtp:pass"]);
                var emailIntercept = System.Configuration.ConfigurationManager.AppSettings["emailintercept"];
                if (!string.IsNullOrEmpty(emailIntercept))
                {
                    message.Subject = "BEF: " + message.Subject;
                    message.To.Clear();
                    message.To.Add(emailIntercept);
                }
                smtpClient.Send(message);
            }
        }
    }
}
