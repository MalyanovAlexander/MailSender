using System.Collections.Generic;

namespace MailSender.ConsoleTest2.Data
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
