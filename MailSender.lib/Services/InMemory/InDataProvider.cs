using MailSender.lib.Entities.Base;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services
{
    public abstract class InDataProvider<T> : IDataProvider<T> where T : BaseEntity
    {
        protected readonly List<T> _Items = new List<T>();

        public IEnumerable<T> GetAll() => _Items;

        public T GetByID(int ID) => _Items.FirstOrDefault(item => item.ID == ID);

        public int Create(T item)
        {
            if (_Items.Contains(item)) return item.ID;
            item.ID = _Items.Count == 0 ? 1 : _Items.Max(r => r.ID) + 1;
            _Items.Add(item);
            return item.ID;
        }

        public abstract void Edit(int ID, T item);

        public bool Remove(int ID)
        {
            var db_item = GetByID(ID);
            return _Items.Remove(db_item);
        }

        public void SaveChanges() { }
    }
}
