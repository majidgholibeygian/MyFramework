using Minio;
using Minio.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MyFramework.Infrastructure.Services
{
    public class MinioService : IMinioService
    {
        private readonly MinioClient _client;
        private readonly MinioSettings _settings;
        private readonly ILogger<MinioService> _logger;

        public MinioService(IOptions<MinioSettings> options, ILogger<MinioService> logger)
        {
            _settings = options.Value;
            _logger = logger;
            // MinioClient builder API depends on Minio package version
            _client = new MinioClient()
                        .WithEndpoint(_settings.Endpoint)
                        .WithCredentials(_settings.AccessKey, _settings.SecretKey)
                        .WithSSL(_settings.Secure)
                        .Build();
        }

        public async Task<string> UploadAsync(Stream stream, string objectName, string contentType, CancellationToken ct = default)
        {
            var bucket = _settings.BucketName;
            try
            {
                bool exists = await _client.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucket), ct);
                if (!exists)
                {
                    await _client.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucket), ct);
                }

                // PutObject expects stream and size; ensure stream is seekable to get length
                if (!stream.CanSeek)
                {
                    var ms = new MemoryStream();
                    await stream.CopyToAsync(ms, ct);
                    ms.Position = 0;
                    stream = ms;
                }

                await _client.PutObjectAsync(new PutObjectArgs()
                    .WithBucket(bucket)
                    .WithObject(objectName)
                    .WithStreamData(stream)
                    .WithObjectSize(stream.Length)
                    .WithContentType(contentType), ct);

                return objectName;
            }
            catch (MinioException ex)
            {
                _logger.LogError(ex, "Minio upload failed");
                throw;
            }
        }

        public async Task<Stream?> DownloadAsync(string objectName, CancellationToken ct = default)
        {
            var bucket = _settings.BucketName;
            try
            {
                bool exists = await _client.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucket), ct);
                if (!exists) return null;

                var ms = new MemoryStream();
                await _client.GetObjectAsync(new GetObjectArgs()
                    .WithBucket(bucket)
                    .WithObject(objectName)
                    .WithCallbackStream((stream) => stream.CopyTo(ms)), ct);

                ms.Position = 0;
                return ms;
            }
            catch (MinioException)
            {
                return null;
            }
        }
    }
}
