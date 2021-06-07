using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace webApiTrader.Controllers
{   
    [Route("Build")]
    public class BuildController : ControllerBase
    {
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
