using Learn.D1.api.Models.TestModels;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;

namespace Learn.D1.api.Features.TestFeature
{
    public class AppInfoService
    {
        private readonly AppInfo _appInfo;

        public AppInfoService(IOptions<AppInfo> options)
        {
            _appInfo = options.Value;
        }

        public async Task<AppInfo> GetAppInfo()
        {
            return _appInfo;
        }
    }
}
