using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.EF
{
    class MailSenderDB : DbContext
    {
        static MailSenderDB() =>
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailSenderDB, Migrations.Configuration>());

        public DbSet<EMail> Emails { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<RecipientsList> RecipientLists { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Server> Servers { get; set; }

        public MailSenderDB() : this("name = MailSenderDB") { }

        public MailSenderDB(string Connection) : base(Connection) { }
    }
}
