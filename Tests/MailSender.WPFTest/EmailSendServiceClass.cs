using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Windows;

namespace MailSender.WPFTest
{
    /// <summary>
    /// Класс для отправки писем
    /// </summary>
    public class EmailSendServiceClass
    {
        public string username;
        public SecureString password;
        public string subject;
        public string text;

        public EmailSendServiceClass(string Username, SecureString Password, string Subject, string Text)
        {
            this.username = Username;
            this.password = Password;
            this.subject = Subject;
            this.text = Text;
        }
        
        /// <summary>
        /// Отправить письмо
        /// </summary>
        public void SendMsg()
        {
            using (SmtpClient client = new SmtpClient(MailServer.host, MailServer.port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(username, password);

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(MailServer.adressFrom, MailServer.nameFrom);
                    message.To.Add(new MailAddress(MailServer.adressTo));
                    message.Subject = subject;
                    message.Body = text;

                    try
                    {
                        client.Send(message);                        

                        SendEndWindow sew = new SendEndWindow();
                        sew.ShowDialog();
                    }
                    catch (Exception error)
                    {
                        SendErrorWindow sew = new SendErrorWindow(error.Message);
                        sew.ShowDialog();                        
                    }
                }
            }
        }
    }
}
