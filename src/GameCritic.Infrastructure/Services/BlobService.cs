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

        public BlobService(BlobServiceClient blobClient, string containerName)
        {
            _containerClient = blobClient.GetBlobContainerClient(containerName);
        }

        public async Task<string> UploadBlob(IFormFile file)
        {
            List<string> extensions = new() { ".jpg", ".jpeg", ".png", ".webp" };

            if (file == null || (file.Length < 1 || file.Length > 10000000))
                throw new ResponseException(HttpStatusCode.BadRequest, string.Format("File is too big or doesn't exist", 3));

            var extension = Path.GetExtension(file.FileName);

            if (!extensions.Contains(extension))
                throw new ResponseException(HttpStatusCode.BadRequest, $"Unsupported {extension} extension");

            var encodedBlobName = Guid.NewGuid() + extension;

            BlobClient blobClient = _containerClient.GetBlobClient(encodedBlobName);

            BlobHttpHeaders httpHeaders = new BlobHttpHeaders { ContentType = file.ContentType };

            var response = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            if (response == null)
                throw new ResponseException(HttpStatusCode.BadRequest, $"Can't upload {file.Name}");

            return encodedBlobName;
        }

        public async Task DeleteBlob(string name)
        {
            var blobClient = _containerClient.GetBlobClient(name);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<Stream> GetBlob(string name)
        {
            var blobClient = _containerClient.GetBlobClient(name);

            if (!await blobClient.ExistsAsync())
                throw new ResponseException(HttpStatusCode.BadRequest, $"File {name} was not found");

            return await blobClient.OpenReadAsync();
        }
    }
}
