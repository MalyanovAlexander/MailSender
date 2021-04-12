using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using MailSender.lib.Services;
using MailSender.lib.Data.LINQtoSQL;
using MailSender.lib.Services.Interfaces;

namespace MailSender.ViewModel
{
   
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var services = SimpleIoc.Default;
            
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);            

            services.Register<MainWindowViewModel>();

            services.Register<IRecipientsDataProvider, LINQ2SQLRecipientsDataProvider>();
            //services.Register<IRecipientsDataProvider, InMemoryRecipientsDataProvider>();
            services.Register(() => new MailSenderDBDataContext());
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}