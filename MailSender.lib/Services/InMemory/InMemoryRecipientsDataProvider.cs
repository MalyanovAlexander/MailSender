﻿using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class InMemoryRecipientsDataProvider : InDataProvider<Recipient>, IRecipientsDataProvider
    {
        public override void Edit(int ID, Recipient item)
        {
            var db_item = GetByID(ID);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Adress = item.Adress;
        }
    }
}
