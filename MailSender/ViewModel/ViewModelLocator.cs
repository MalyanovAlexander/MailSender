using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using MailSender.lib.Services;
using MailSender.lib.Data.LINQtoSQL;
using MailSender.lib.Services.Interfaces;
using System;

namespace MailSender.ViewModel
{

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var services = SimpleIoc.Default;
            
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);            

            services.Register<MainWindowViewModel>();

            services
                .TryRegister<IRecipientsDataProvider, LINQ2SQLRecipientsDataProvider>()
                .TryRegister(() => new MailSenderDBDataContext())
                /*.TryRegister(() => new MailSenderDB())*/; //не видит пространство имён

            //services.TryRegister<IRecipientsDataProvider, InMemoryRecipientsDataProvider>()
            //.TryRegister<ISendersDataProvider, InMemorySendersDataProvider>()
            //.TryRegister<IServersDataProvider, InMemoryServersDataProvider>();            
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();            
    }

    public static class SimpleIocExtentions
    {
        public static SimpleIoc TryRegister<TInterface, TService>(this SimpleIoc services)
            where TInterface : class
            where TService : class, TInterface
        {
            if (services.IsRegistered<TInterface>()) return services;
            services.Register<TInterface, TService>();
            return services;
        }

        public static SimpleIoc TryRegister<TService>(this SimpleIoc services)
            where TService : class
        {
            if (services.IsRegistered<TService>()) return services;
            services.Register<TService>();
            return services;
        }

        public static SimpleIoc TryRegister<TService>(this SimpleIoc services, Func<TService> Factory)
            where TService : class
        {
            if (services.IsRegistered<TService>()) return services;
            services.Register(Factory);
            return services;
        }


    }
}
