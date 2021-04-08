using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.lib.Data.LINQtoSQL;
using MailSender.lib.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        private ObservableCollection<Recipient> _Recipients = new ObservableCollection<Recipient>();

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

        #region Выбранный получатель
        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }
        #endregion

        public ICommand RefrechDataCommand { get; }

        public ICommand SaveChangesCommand { get; }



        public MainWindowViewModel(RecipientsDataProvider RecipientsProvider)
        {
            _RecipientsProvider = RecipientsProvider;

            RefrechDataCommand = new RelayCommand(OnRefreshDataCommandExecuted, CanRefreshDataCommandExecute);
            SaveChangesCommand = new RelayCommand(OnSaveChangesCommanExecuted);
        }
        private void OnSaveChangesCommanExecuted()
        {
            _RecipientsProvider.SaveChanges();
        }

        private bool CanRefreshDataCommandExecute() => true;

        private void OnRefreshDataCommandExecuted()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = new ObservableCollection<Recipient>();            
            foreach (var recipient in _RecipientsProvider.GetAll())
            {
                recipients.Add(recipient);
            }
            Recipients = recipients;
        }
    }
}
