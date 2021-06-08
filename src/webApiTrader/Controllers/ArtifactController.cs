using AzureDevOps.Integration.DataProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using webApiTrader.Configurations;

namespace webApiTrader.Controllers
{
    [Route("Artifact")]
    public class ArtifactController : ControllerBase
    {
        private ApplicationSettings _settings { get; set; }
        private BuildDataContext _context;
        public ArtifactController(IOptions<ApplicationSettings> settings, BuildDataContext context)
        {
            _settings = settings.Value;
            _context = context;
        }

        [HttpGet]
        [Route("Artifact/")]
        public async Task<IActionResult> GetProjects()
        {
            using (_context)
            {
                _context.Blogs.Where(x => x.BlogId == 1);
            };

            await Task.Delay(1000);
            return Ok(DateTime.Now);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetArtifactByProjectId(int id)
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
