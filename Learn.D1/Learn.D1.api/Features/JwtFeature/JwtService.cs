using Learn.D1.api.Models.JwtModels;
using Microsoft.Extensions.Options;

namespace Learn.D1.api.Features.JwtFeature
{
    public class JwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public async Task<JwtSettings> TestJwtsetting()
        {
            var issuer = _jwtSettings;
            return issuer;
        }
    }
}
