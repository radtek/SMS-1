using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Helpers
{
    public static class SmtpHelper
    {
        public static void Send(MailMessage message)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
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
