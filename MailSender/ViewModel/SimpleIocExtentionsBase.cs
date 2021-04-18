namespace MailSender.ViewModel
{
    public static class SimpleIocExtentionsBase
    {
        public static SimpleIoc TryRegister<TInterface, TService>(this SimpleIoc services)
        {
            return services;
        }
    }
}