using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server{ID = 0, Name = "Yandex.ru", Adress = "smtp.yandex.ru", UserName = "username", Password = "password"},
            new Server{ID = 1, Name = "Mail.ru", Adress = "smtp.mail.ru", UserName = "username", Password = "password"},
            new Server{ID = 2, Name = "Gmail.com", Adress = "smtp.gmail.com", Port = 465, UserName = "username", Password = "password"}
        };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender{ID = 0, Name = "Ivanov", Adress = "ivanov@yandex.ru"},
            new Sender{ID = 1, Name = "Petrov", Adress = "petrov@mail.ru"},
            new Sender{ID = 2, Name = "Sidorov", Adress = "sidorov@gmail.com"}
        };
    }
}
