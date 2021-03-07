using System;
using System.Net;
using System.Net.Mail;
using System.Windows;


namespace MailSender.WPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            var user_name = UserNameEditor.Text;                                                           //Получаем логин и пароль с окна
            var password = PasswordEditor.SecurePassword;
            var subject = MessageSubject.Text;
            var text = MessageText.Text;

            EmailSendServiceClass email = new EmailSendServiceClass(user_name, password, subject, text);   //Создаём экземпляр класса для отправки письма
            email.SendMsg();                                                                               //Отправляем письмо
        }
    }
}
