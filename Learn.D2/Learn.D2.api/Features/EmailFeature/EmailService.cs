using Learn.D2.api.Models.Settings;
using Microsoft.Extensions.Options;

namespace Learn.D2.api.Features.EmailFeature
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task<EmailSettings> GetEmailSettingsAsync()
        {
            return _emailSettings;
        }
    }
}

