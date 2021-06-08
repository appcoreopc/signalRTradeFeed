using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using webApiTrader.Configurations;

namespace webApiTrader.Controllers
{   
    [Route("Build")]
    public class BuildController : ControllerBase
    {
        private ApplicationSettings _settings { get; set; }

        public BuildController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }
        [HttpPost]
        public async Task<IActionResult> RunPipeline()
        {
            await Task.Delay(1000);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPipelinesInfo()
        {
            await Task.Delay(1000);
            return Ok();
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetPipelineStatus(int id)
        {
            await Task.Delay(1000);
            return Ok();
        }
    }
}
