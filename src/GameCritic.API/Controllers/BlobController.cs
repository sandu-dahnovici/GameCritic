using static HeyRed.Mime.MimeTypesMap;
using GameCritic.API.Controllers;
using GameCritic.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameCritic.API.Controllers
{
    [Route("api/blob")]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService _service;

        public BlobController(IBlobService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetBlobUri(string name)
        {
            var stream = await _service.GetBlob(name);
            var mime = GetMimeType(Path.GetExtension(name));
            return File(stream, mime, name);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteBlob(string name)
        {
            await _service.DeleteBlob(name);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlob(IFormFile file)
        {
            var result = await _service.UploadBlob(file);
            return Ok(result);
        }
    }
}


