// src/MyFramework.Web/Controllers/FilesController.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFramework.Infrastructure.Services.Minio;
using System.IO;
using System.Threading.Tasks;

namespace MyFramework.Web.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly IMinioService _minio;
        public FilesController(IMinioService minio) => _minio = minio;

        [HttpPost("upload")]
        [RequestSizeLimit(857286400)]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("file missing");
            using var stream = file.OpenReadStream();
            var id = Path.GetFileName(file.FileName);
            var objectName = $"{System.Guid.NewGuid()}-{id}";
            await _minio.UploadAsync(stream, objectName, file.ContentType);
            return Ok(new { objectName });
        }

        [HttpGet("download/{objectName}")]
        public async Task<IActionResult> Download(string objectName)
        {
            var stream = await _minio.DownloadAsync(objectName);
            if (stream == null) return NotFound();
            return File(stream, "application/octet-stream", objectName);
        }
    }
}