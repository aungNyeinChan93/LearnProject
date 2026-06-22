using Learn.D2.api.Models.Settings;
using Microsoft.Extensions.Options;

namespace Learn.D2.api.Features.FirebaseFeature
{
    public class FirebaseService
    {
        private readonly FirebaseSettings _firebaseSettings;

        public FirebaseService(IOptions<FirebaseSettings> options)
        {
            _firebaseSettings = options.Value;
        }

        public async Task<FirebaseSettings>  GetSettingsAsync()
        {
            return _firebaseSettings;
        }
    }
}
