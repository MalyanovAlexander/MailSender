
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services
{
    public class InMemoryRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly List<Recipient> _Recipients = new List<Recipient>();

        public int Create(Recipient recipient)
        {
            if (_Recipients.Contains(recipient)) return recipient.ID;
            recipient.ID = _Recipients.Count == 0 ? 1 : _Recipients.Max(r => r.ID) + 1;
            _Recipients.Add(recipient);
            return recipient.ID;
        }

        public void Edit(int ID, Recipient item)
        {
            var db_item = GetByID(ID);
            if (db_item is null) return;
            db_item.Name = item.Name;
            db_item.Adress = item.Adress;            
        }

        public IEnumerable<Recipient> GetAll() => _Recipients;

        public Recipient GetByID(int ID) => _Recipients.FirstOrDefault(r => r.ID == ID);

        public bool Remove(int ID)
        {
            var db_item = GetByID(ID);
            return _Recipients.Remove(db_item);

        }

        public void SaveChanges(){}
    }
}
