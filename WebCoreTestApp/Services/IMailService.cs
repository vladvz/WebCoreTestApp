namespace WebCoreTestApp.Services
{
    public interface IMailService
    {
        void SendMessage(string subject, string to, string body);
    }
}