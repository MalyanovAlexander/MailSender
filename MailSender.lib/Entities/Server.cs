using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Server : NamedEntity
    {        
        public string Host { get; set; }
        public int Port { get; set; } = 25;
        public bool UseSSL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Descrition { get; set; }
    }
}
