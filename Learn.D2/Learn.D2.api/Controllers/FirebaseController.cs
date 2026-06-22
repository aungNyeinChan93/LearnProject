using Learn.D2.api.Features.FirebaseFeature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Learn.D2.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirebaseController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public FirebaseController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        [HttpGet]
        [Route("firebaseService")]
        public async Task<IActionResult> GetFirebaseSettings()
        {
            return Ok(await _firebaseService.GetSettingsAsync());
        } 
    }
}
