using Microsoft.AspNetCore.Http;

namespace GameCritic.Application.Common.Interfaces.Services
{
    public interface IBlobService
    {
        Task<Stream> GetBlob(string name);
        Task<string> UploadBlob(IFormFile file);
        Task DeleteBlob(string name);
    }
}
