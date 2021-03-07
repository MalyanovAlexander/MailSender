namespace MailSender.lib.Entities
{
    public class Server
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Port { get; set; } = 25;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Descrition { get; set; }
    }
}
