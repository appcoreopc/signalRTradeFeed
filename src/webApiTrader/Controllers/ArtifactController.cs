using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace webApiTrader.Controllers
{
    [Route("Artifact")]
    public class ArtifactController : ControllerBase
    {       
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            await Task.Delay(1000);
            return Ok(DateTime.Now);
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetProjectsById()
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
                    string filePath = Path.Combine(@"c:\temp", file.FileName);
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
