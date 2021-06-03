using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace webApiTrader.Controllers
{
    public class BuildController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RunPipeline()
        {
            await Task.Delay(1000);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPipeline()
        {
            await Task.Delay(1000);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPipelineStatus()
        {
            await Task.Delay(1000);
            return Ok();
        }
    }
}
