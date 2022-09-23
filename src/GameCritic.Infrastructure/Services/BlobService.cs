using System.Net;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GameCritic.Application.Common.Interfaces.Services;
using GameCritic.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace GameCritic.Infrastructure.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobContainerClient _containerClient;
        private readonly List<string> _extensions = new() { ".jpg", ".jpeg", ".png", ".webp" };

        public BlobService(BlobServiceClient blobClient, string containerName)
        {
            _containerClient = blobClient.GetBlobContainerClient(containerName);
        }

        public async Task<Stream> GetBlob(string name)
        {
            var blobClient = _containerClient.GetBlobClient(name);

            if (!await blobClient.ExistsAsync())
                throw new HttpResponseException(HttpStatusCode.BadRequest, $"File {name} was not found");

            return await blobClient.OpenReadAsync();
        }


        public async Task<string> UploadBlob(IFormFile file)
        {
            if (file == null || (file.Length < 1 || file.Length > 4000000))
                throw new HttpResponseException(HttpStatusCode.BadRequest, string.Format("File is too big or small", 3));

            var extension = Path.GetExtension(file.FileName);

            if (!_extensions.Contains(extension))
                throw new HttpResponseException(HttpStatusCode.BadRequest,
                    $"Unsupported {extension} extension");

            var fileNameInStorage = Guid.NewGuid() + extension;

            var blobClient = _containerClient.GetBlobClient(fileNameInStorage);

            var httpHeaders = new BlobHttpHeaders { ContentType = file.ContentType };

            var res = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            if (res == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest, $"Can't upload {file.Name}");

            return fileNameInStorage;
        }

        public async Task DeleteBlob(string name)
        {
            var blobClient = _containerClient.GetBlobClient(name);
            await blobClient.DeleteIfExistsAsync();
        }
    }
}
