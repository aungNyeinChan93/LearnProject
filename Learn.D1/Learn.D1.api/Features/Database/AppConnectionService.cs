using Learn.D1.api.Models.DbModles;
using Microsoft.Extensions.Options;

namespace Learn.D1.api.Features.Database
{
    public class AppConnectionService
    {
        private AppConnection _appConnection;

        public AppConnectionService(IOptions<AppConnection> options)
        {
            _appConnection = options.Value;
        }

        public async Task<AppConnection> GetAppConnectionSettings()
        {
            return _appConnection;
        }
    }
}
