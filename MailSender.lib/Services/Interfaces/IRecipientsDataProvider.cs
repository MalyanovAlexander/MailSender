using System.Collections.Generic;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsDataProvider
    {
        IEnumerable<Recipient> GetAll();

        Recipient GetByID(int ID);

        int Create(Recipient item);

        void Edit(int ID, Recipient item);

        bool Remove(int ID);

        void SaveChanges();
    }
}
