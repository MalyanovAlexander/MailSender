using GalaSoft.MvvmLight;
using MailSender.lib.Data.LINQtoSQL;
using MailSender.lib.Services;
using System.Collections.ObjectModel;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RecipientsDataProvider _RecipientsProvider;
        private string _WindowTitle = "Рассыльщик почты v0.1";

        public string WindowTitle
        {
            get => _WindowTitle;
            set => Set(ref _WindowTitle, value);
        }

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        public MainWindowViewModel(RecipientsDataProvider RecipientsProvider)
        {
            _RecipientsProvider = RecipientsProvider;

            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = Recipients;
            recipients.Clear();
            foreach (var recipient in _RecipientsProvider.GetAll())
            {
                recipients.Add(recipient);
            }
        }
    }
}
