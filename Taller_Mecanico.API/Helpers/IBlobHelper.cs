using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller_Mecanico.API.Helpers
{
    public interface IBlobHelper
    {
        Task<Guid> UploadBlobAsync(IFormFile file, string nombreContenedor);

        Task<Guid> UploadBlobAsync(byte[] file, string nombreContenedor);

        Task<Guid> UploadBlobAsync(string image, string nombreContenedor);

        Task DeleteBlobAsync(Guid id, string nombreContenedor);
    }
}
