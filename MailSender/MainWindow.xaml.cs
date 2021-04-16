using System;
using System.Windows;
using System.Windows.Documents;

namespace MailSender
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

        /// <summary>
        /// Переход на вкладку слева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLeftButtonClick(object sender, EventArgs e)
        {
            if (!(sender is Controls.TabItemsSwitcher switcher)) return;
            if (MainTabControl.SelectedIndex == 0) return;

            MainTabControl.SelectedIndex--;
            if (MainTabControl.SelectedIndex == 0)
            {
                switcher.LeftButtonVisible = false;
            }
        }

        /// <summary>
        /// Переход на вкладку справа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRightButtonClick(object sender, EventArgs e)
        {
            if (!(sender is Controls.TabItemsSwitcher switcher)) return;
            var tabcount = MainTabControl.Items.Count;

            if (MainTabControl.SelectedIndex == tabcount - 1) return;
            MainTabControl.SelectedIndex++;
            if (MainTabControl.SelectedIndex == MainTabControl.Items.Count-1)
            {
                switcher.RightButtonVisible = false;
            }
        }

        /// <summary>
        /// Переход на вкладку планировщика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToPlanner_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = Planner;
        }

        /// <summary>
        /// Отправить письмо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendMSG_Click(object sender, RoutedEventArgs e)
        {
            var user_name = MailServer.adressFrom;                                                           //Получаем логин и пароль с окна
            var password = "DerIgel1991";
            var subject = MailServer.subject;            
            var text = new TextRange(RichTB.Document.ContentStart, RichTB.Document.ContentEnd).Text;

            EmailSendServiceClass email = new EmailSendServiceClass(user_name, password, subject, text);   //Создаём экземпляр класса для отправки письма
            if (text == "" || text =="\r\n")            //Проверяем заполненность RichTextBox
            {
                MessageBox.Show("Письмо не заполнено");
                MainTabControl.SelectedIndex = 2;
                return;
            }
            email.SendMsg();
        }
    }
}


//6. По аналогии с тем, как создавали DLL из класса, который шифрует пароли, создать DLL из класса EmailSendServiceClass,
//который занимается рассылкой писем. 


//7. Посмотреть на ToolBarTray:
//Некоторые панели ToolBar похожи, и из них можно сделать контрол и добавлять на ToolBar.
//Задание: сделать контрол из панели «Выбрать отправителя» и добавить его в качестве контрола «Выбрать smtp-server».
//У этого контрола должна быть возможность заменить текст у лейбла, должен функционировать комбобокс и все три кнопки. 

//Реализовать работу поля Фильтр

