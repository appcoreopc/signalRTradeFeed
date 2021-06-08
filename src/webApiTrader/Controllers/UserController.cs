using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using webApiTrader.Configurations;

namespace webApiTrader.Controllers
{
    [Route("Artifact")]
    public class UserController : ControllerBase
    {
        private ApplicationSettings _settings { get; set; }

        public UserController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetProject(int id)
        {
            await Task.Delay(1000);
            return Ok(DateTime.Now);
        }
    }       
}
