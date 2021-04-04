using MailSender.lib.Data.LINQtoSQL;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services
{
    public class RecipientsDataProvider
    {
        private readonly MailSenderDBDataContext _db;

        public RecipientsDataProvider(MailSenderDBDataContext db) { _db = db; }

        public IEnumerable<Recipient> GetAll() => _db.Recipient.ToArray();
    }
}
