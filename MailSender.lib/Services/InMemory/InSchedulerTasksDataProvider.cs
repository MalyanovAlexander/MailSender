using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class InSchedulerTasksDataProvider : InDataProvider<SchedulerTask>, ISchedulerTasksProvider
    {
        public override void Edit(int ID, SchedulerTask item)
        {
            var db_item = GetByID(ID);
            if (db_item is null) return;

            db_item.Time = item.Time;
            db_item.Sender = item.Sender;
            db_item.Recipients = item.Recipients;
            db_item.Email = item.Email;
            db_item.Server = item.Server;
        }
    }
}
