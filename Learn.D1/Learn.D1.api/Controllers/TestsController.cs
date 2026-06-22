using Learn.D1.api.Features.Database;
using Learn.D1.api.Features.JwtFeature;
using Learn.D1.api.Features.TestFeature;
using Learn.D1.api.Models.TestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace Learn.D1.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly AppInfoService _appInfoService;
        private readonly AppConnectionService _appConnectionService;
        public TestsController(JwtService jwtService, AppInfoService appInfoService, AppConnectionService appConnectionService)
        {
            _jwtService = jwtService;
            _appInfoService = appInfoService;
            _appConnectionService = appConnectionService;
        }

        [HttpGet]
        [Route("JwtSettings")]
        public async Task<IActionResult> JwtSettings()
        {
            var result = await _jwtService.TestJwtsetting();
            return Ok(result);
        }

        [HttpGet]
        [Route("AppInfo")]
        public async Task<IActionResult> AppInfo()
        {
            var result = await _appInfoService.GetAppInfo();
            return Ok(result);
        }

        [HttpGet]
        [Route("getAppConnectionSetting")]
        public async Task<IActionResult> GetAppConecctionSetting()
        {
            var res =  _appConnectionService.GetAppConnectionSettings();
            return Ok(res);
        }

        [HttpGet]
        [Route("env")]
        public async Task<IActionResult> TestEnv()
        {
            var appName = Environment.GetEnvironmentVariable("tests2.name");
            return Ok(appName);
        }
    }
}
