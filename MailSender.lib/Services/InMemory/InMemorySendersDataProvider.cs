using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Linq;

namespace MailSender.lib.Services
{
    public class InMemorySendersDataProvider : InDataProvider<Sender>, ISendersDataProvider
    {

        public InMemorySendersDataProvider()
        {
            _Items.AddRange(Enumerable.Range(1, 10).Select(i => new Sender { ID = i, Name = $"Отправитель {i}", Adress = $"sender{i}@server.com" }));
        }

        public override void Edit(int ID, Sender item)
        {
            var db_item = GetByID(ID);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Adress = item.Adress;
        }
    }
}
