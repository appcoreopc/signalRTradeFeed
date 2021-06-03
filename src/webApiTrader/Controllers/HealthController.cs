using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace webApiTrader.Controllers
{
    public class HealthController : ControllerBase
    {       
        [HttpGet]
        public async Task<IActionResult> Ping()
        {
            await Task.Delay(1000);
            return Ok(DateTime.Now);
        }    
    }
}
