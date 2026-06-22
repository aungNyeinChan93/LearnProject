using Learn.D2.api.Features.EmailFeature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.D2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        [Route("emailService")]
        public async Task<IActionResult> GetEmailSettings()
        {
            return Ok(await _emailService.GetEmailSettingsAsync());
        }
    }
}
