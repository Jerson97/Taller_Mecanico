using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Helpers
{
    public class BlobHelper : IBlobHelper
    {
        private readonly CloudBlobClient _blobClient;
        public BlobHelper(IConfiguration configuration)
        {
            string keys = configuration["Blob:ConnectionString"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(keys);
            _blobClient = storageAccount.CreateCloudBlobClient();
        }
        public async Task DeleteBlobAsync(Guid id, string nombreContenedor)
        {
            CloudBlobContainer contenedor = _blobClient.GetContainerReference(nombreContenedor);
            CloudBlockBlob blockBlob = contenedor.GetBlockBlobReference($"{id}");
            await blockBlob.DeleteAsync();
        }

        public async Task<Guid> UploadBlobAsync(IFormFile file, string nombreContenedor)
        {
            Stream stream = file.OpenReadStream();
            Guid nombre = Guid.NewGuid();
            CloudBlobContainer contenedor = _blobClient.GetContainerReference(nombreContenedor);
            CloudBlockBlob blockBlob = contenedor.GetBlockBlobReference($"{nombre}");
            await blockBlob.UploadFromStreamAsync(stream);
            return nombre;
        }

        public async Task<Guid> UploadBlobAsync(byte[] file, string nombreContenedor)
        {
            MemoryStream stream = new MemoryStream(file);
            Guid nombre = Guid.NewGuid();
            CloudBlobContainer contenedor = _blobClient.GetContainerReference(nombreContenedor);
            CloudBlockBlob blockBlob = contenedor.GetBlockBlobReference($"{nombre}");
            await blockBlob.UploadFromStreamAsync(stream);
            return nombre;
        }

        public async Task<Guid> UploadBlobAsync(string image, string nombreContenedor)
        {
            Stream stream = File.OpenRead(image);
            Guid nombre = Guid.NewGuid();
            CloudBlobContainer contenedor = _blobClient.GetContainerReference(nombreContenedor);
            CloudBlockBlob blockBlob = contenedor.GetBlockBlobReference($"{nombre}");
            await blockBlob.UploadFromStreamAsync(stream);
            return nombre;
        }
    }
}
