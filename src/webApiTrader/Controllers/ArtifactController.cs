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
    public class ArtifactController : ControllerBase
    {
        private ApplicationSettings _settings { get; set; }

        public ArtifactController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }

        [HttpGet]        
        public async Task<IActionResult> GetProjects()
        {
            await Task.Delay(1000);
            return Ok(DateTime.Now);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProjectsById(int id)
        {
            await Task.Delay(1000);
            return Ok(DateTime.Now);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile[] files)
        {
            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(_settings.ImagePath, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return Ok(DateTime.Now);
        }
    }
}
