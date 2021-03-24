using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    class MailServer
    {
        public static string host = "smtp.mail.ru";
        public static int port = 25;

        public static string adressFrom = "malyanov_91@mail.ru";
        public static string nameFrom = "Ёж";
        public static string adressTo = "malyanov_91@mail.ru";
        public static string subject = "Заголовок письма от " + DateTime.Now;
        public static string msg = "Hello World " + DateTime.Now;

        public static string messageBoxSuccessText = "Почта успешно отправлена!";
        public static string messageBoxSuccessCaption = "Успех!";
        public static string messageBoxErrorCaption = "Ошибка!";
    }
}
