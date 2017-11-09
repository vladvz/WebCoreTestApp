using Microsoft.Extensions.Logging;

namespace WebCoreTestApp.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> _logger;

        public MailService(ILogger<MailService> logger)
        {
            _logger = logger;
        }

        public void SendMessage(string subject, string to, string body)
        {
            _logger.LogInformation($"Subject: {subject} To: {to} Body: {body}");
        }
    }
}
