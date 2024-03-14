using CuentasDiarias.Domain.Entity.Publicaciones;
using Microsoft.AspNetCore.Http;

namespace CuentasDiarias.Domain.Interface.Publicaciones
{
    public interface IAzureBlob
    {
        Task<List<Blob>> ListAsync(string containerName);
        Task<BlobResponse> UploadAsync(IFormFile blob,string containerName);
        Task<Blob> DownloadAsync(string blobFilename);
        Task<BlobResponse> DeleteAsync(string blobFilename);

        Task<BlobResponse> CreateContainer();
    }
}
