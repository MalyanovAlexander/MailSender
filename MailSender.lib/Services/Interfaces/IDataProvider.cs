using System.Collections.Generic;

namespace MailSender.lib.Services.Interfaces
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetAll();

        T GetByID(int ID);

        int Create(T item);

        void Edit(int ID, T item);

        bool Remove(int ID);

        void SaveChanges();
    }
}
