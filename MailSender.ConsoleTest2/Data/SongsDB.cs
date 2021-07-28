﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest2.Data
{
    //В консоли диспетчера пакетов: Update-Database -Verbose

    public class SongsDB : DbContext
    {
        public SongsDB(string ConnectionString) : base(ConnectionString) { }

        public SongsDB() : this("name=SongsDB") { }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}
