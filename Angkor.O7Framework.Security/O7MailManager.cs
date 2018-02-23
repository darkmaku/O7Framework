using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Angkor.O7Framework.Common.Model;

namespace Angkor.O7Framework.Utility
{

    public  class O7MailManager
    {
        private string host;
        private string port;
        private string username;
        private string password;

        public void SetParameters(O7MailParameters parameters)
        {

            host = parameters.Host;
            port = parameters.Port;
            username = parameters.User;
            password = parameters.Password;

        }  private readonly string Apikey = WebConfigurationManager.AppSettings["O7WEB_FILE_API_KEY"];
        private string Host = WebConfigurationManager.AppSettings["O7WEB_FILE_HOST"];
        public int SendEmail(O7MailMessage message)
        {
            try
            {
                SmtpClient client = new SmtpClient();

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                if (host == "")
                {
                    client.Host = WebConfigurationManager.AppSettings["O7WEB_MAIL_HOST"] ;
                    client.Port = Int32.Parse(WebConfigurationManager.AppSettings["O7WEB_MAIL_PORT"]);
                    client.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["O7WEB_MAIL_USER"], WebConfigurationManager.AppSettings["O7WEB_MAIL_PASS"]);
                }
                else
                {
                    client.Host = host;
                    client.Port = Int32.Parse(port);
                    client.Credentials = new System.Net.NetworkCredential(username, password);

                }
                MailMessage mail = new MailMessage(message.From, message.To);
                mail.Subject = message.Subject;
                mail.IsBodyHtml = true;
                mail.Body = message.Body;
                foreach (var atc in message.Attachments)
                {
                    mail.Attachments.Add(atc);
                }
                client.Send(mail);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }

}
