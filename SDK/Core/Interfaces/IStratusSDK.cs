using StratusSDK.Api.Bucket.CreateBucketSignature.Models;
using StratusSDK.Api.Bucket.GetBuckets.Models;
using StratusSDK.Api.Bucket.ListBuckets.Models;
using StratusSDK.Api.DeletePath.Models;
using StratusSDK.Api.GetStatusOfZipExtract.Models;
using StratusSDK.Api.Object.CopyObject.Models;
using StratusSDK.Api.Object.DeleteObject.Models;
using StratusSDK.Api.Object.DownloadObject.Models;
using StratusSDK.Api.Object.ExistsObject.Models;
using StratusSDK.Api.Object.ExtractZipObject.Models;
using StratusSDK.Api.Object.GetAllObjectVersions.Models;
using StratusSDK.Api.Object.GetObject.Models;
using StratusSDK.Api.Object.ListAllObjects.Models;
using StratusSDK.Api.Object.PutObjectMetadata.Models;
using StratusSDK.Api.Object.RenameObject.Models;
using StratusSDK.Api.Object.UploadObject.Models;
using StratusSDK.Api.PresignedUrl.Models;
using StratusSDK.Core.Enums;
using StratusSDK.Core.Interfaces;
using StratusSDK;
using StratusSDK.Api.Bucket.ExistsBucket.Models;

namespace StratusSDK.Core.Interfaces
{
    public interface IStratusSDK
    {
        public Task<CopyObjectResponse> CopyObjectAsync(
            string objectKey,
            string destination,
            CancellationToken ct = default);
        public Task<CreateBucketSignatureResponse> CreateBucketSignatureAsync(
            CancellationToken ct = default);
        public Task<DeleteObjectResponse> DeleteObjectAsync(
            string objectKey,
            string? versionId = null,
            int? ttlInSeconds = null,
            CancellationToken ct = default);
        public Task<DeleteObjectResponse> DeleteObjectsAsync(
            List<DeleteObjectRequestData> objectKeys,
            int? ttlInSeconds = null,
            CancellationToken ct = default);
        public Task<DeleteObjectResponse> DeleteObjectsAsync(
            List<string> objectKeys,
            int? ttlInSeconds = null,
            CancellationToken ct = default);
        public Task<DeletePathResponse> DeletePathAsync(
            string prefix,
            CancellationToken ct = default);
        public Task<DownloadObjectResponse> DownloadObjectAsync(
            DownloadObjectRequest request,
            CancellationToken ct = default);
        public Task<ExistsBucketResponse> ExistsBucketAsync(
            CancellationToken ct = default);
        public Task<ExistsObjectResponse> ExistsObjectAsync(
            string objectKey,
            string? versionId = null,
            CancellationToken ct = default);
        public Task<ExtractZipObjectResponse> ExtractZipObjectAsync(
            string objectKey,
            string destination,
            CancellationToken ct = default);
        public Task<GetAllObjectVersionsResponse> GetObjectVersionsAsync(
            string objectKey,
            int? maxVersion = null,
            string? continuationToken = null,
            CancellationToken ct = default);
        public Task<GetBucketResponse> GetBucketAsync(
            CancellationToken ct = default);
        public Task<GetObjectResponse> GetObjectAsync(
            string objectKey,
            string? versionId = null,
            CancellationToken ct = default);
        public Task<GetStatusOfZipExtractResponse> GetExtractionStatusAsync(
            string taskId,
            CancellationToken ct = default);
        public Task<PresignedURLResponse> GetPresignedURLAsync(
            EPresignedType Type,
            string objectKey,
            PresignedUrlOptions? options = null,
            CancellationToken ct = default);
        public Task<ListBucketResponse> ListAllBucketsAsync(
            CancellationToken ct = default);
        public Task<ListAllObjectsResponse> ListAllObjectsAsync(
            int? MaxKeys = null,
            string? ContinuationToken = null,
            string? Prefix = null,
            CancellationToken ct = default);

        public Task<PutObjectMetadataResponse> PutObjectMetadataAsync(
            string objectKey,
            PutObjectMetadataRequestBody content,
            CancellationToken ct = default);
        public Task<RenameObjectResponse> RenameObjectAsync(
            string currentKey,
            string renameTo,
            CancellationToken ct = default);
        public Task<UploadObjectResponse> UploadAsync(
            string objectKey,
            IStratusHttpContent content,
            EContentType contentType = EContentType.TextPlain,
            UploadObjectRequestOptions? options = null,
            CancellationToken ct = default);

        // Helper methods
        public string GetObjectURL(string objectKey);
    }
}