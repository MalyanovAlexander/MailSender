using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class InMemoryServersDataProvider : InDataProvider<Server>, IServersDataProvider
    {
        public override void Edit(int ID, Server item)
        {
            var db_item = GetByID(ID);
            if (db_item is null) return;

            db_item.Host = item.Host;
            db_item.Port = item.Port;
            db_item.UseSSL = item.UseSSL;
            db_item.UserName = item.UserName;
            db_item.Password = item.Password;
        }
    }
}
