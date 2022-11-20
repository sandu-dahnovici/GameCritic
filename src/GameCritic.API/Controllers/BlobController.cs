using static HeyRed.Mime.MimeTypesMap;
using GameCritic.API.Controllers;
using GameCritic.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GameCritic.API.Filters;
using GameCritic.Domain.Auth;

namespace GameCritic.API.Controllers
{
    [Route("api/blob")]
    [HttpResponseExceptionFilter]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService _service;

        public BlobController(IBlobService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetBlobUri(string name)
        {
            var stream = await _service.GetBlob(name);
            var mime = GetMimeType(Path.GetExtension(name));
            return File(stream, mime, name);
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteBlob(string name)
        {
            await _service.DeleteBlob(name);
            return NoContent();
        }

        [Authorize(Roles = RoleCategory.Admin)]
        [HttpPost]
        public async Task<IActionResult> UploadBlob(IFormFile file)
        {
            var result = await _service.UploadBlob(file);
            return Ok(result);
        }
    }
}


