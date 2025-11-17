using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Infrastructure.Services.Minio
{
    public interface IMinioService
    {
        Task<string> UploadAsync(Stream stream, string objectName, string contentType, CancellationToken ct = default);
        Task<Stream?> DownloadAsync(string objectName, CancellationToken ct = default);
    }
}
