using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services
{
    public class LINQ2SQLRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly Data.LINQtoSQL.MailSenderDBDataContext _db;

        public LINQ2SQLRecipientsDataProvider(Data.LINQtoSQL.MailSenderDBDataContext db) { _db = db; }

        public IEnumerable<Recipient> GetAll()
        {
            _db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            return _db.Recipient.ToArray().Select(r => new Recipient
            {
                ID = r.Id,
                Name = r.Name,
                Adress = r.Adress                
            }); 
        }

        public int Create(Recipient recipient)
        {
            if (recipient is null) throw new ArgumentNullException(nameof(recipient));
            if (recipient.ID != 0) return recipient.ID;

            var entity = new Data.LINQtoSQL.Recipient
            {
                Name = recipient.Name,
                Adress = recipient.Adress
            };

            _db.Recipient.InsertOnSubmit(entity); 
            
            SaveChanges();
            return entity.Id;
        }        

        public Recipient GetByID(int ID)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.Id == ID);
            if (db_item is null) return null;
            return new Recipient
            {
                ID = db_item.Id,
                Name = db_item.Name,
                Adress = db_item.Adress
            };
        }

        public void Edit(int ID, Recipient item)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.Id == ID);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Adress = item.Adress;

            SaveChanges();
        }

        public bool Remove(int ID)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.Id == ID);
            if (db_item is null) return false;

            _db.Recipient.DeleteOnSubmit(db_item);
            SaveChanges();
            return true;
        }

        public void SaveChanges() => _db.SubmitChanges();
    }
}
