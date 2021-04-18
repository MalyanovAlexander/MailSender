using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Linq;

namespace MailSender.lib.Services
{
    public class InMemoryEmailsDataProvider : InDataProvider<EMail>, IEmailsDataProvider
    {
        public InMemoryEmailsDataProvider()
        {
            _Items.AddRange(Enumerable.Range(1, 20).Select(i => new EMail { ID = i, Subject = $"Сообщение {i}", Body = $"Тело письма{i}" }));
        }

        public override void Edit(int ID, EMail item)
        {
            var db_item = GetByID(ID);
            if (db_item is null) return;

            db_item.Subject = item.Subject;
            db_item.Body = item.Body;
        }
    }
}
