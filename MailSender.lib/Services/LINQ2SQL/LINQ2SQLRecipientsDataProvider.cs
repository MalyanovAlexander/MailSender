using MailSender.lib.Data.LINQtoSQL;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services
{
    public class LINQ2SQLRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly MailSenderDBDataContext _db;

        public LINQ2SQLRecipientsDataProvider(MailSenderDBDataContext db) { _db = db; }

        public IEnumerable<Recipient> GetAll()
        {
            _db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            return _db.Recipient.ToArray();
        }

        public int Create(Recipient recipient)
        {
            if (recipient is null) throw new ArgumentNullException(nameof(recipient));

            _db.Recipient.InsertOnSubmit(recipient);
            SaveChanges();
            return recipient.Id;
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
