using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class InRecipientsListsDataProvider : InDataProvider<RecipientsList>, IRecipientsListsDataProvider
    {
        public override void Edit(int ID, RecipientsList item)
        {
            var db_item = GetByID(ID);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Recipients = item.Recipients;
        }
    }
}
