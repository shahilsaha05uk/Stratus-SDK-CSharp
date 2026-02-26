namespace StratusSDK
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
        public Task<UploadObjectResponse> UploadFileAsync(
            string objectKey,
            string filePath,
            EContentType contentType = EContentType.TextPlain,
            UploadObjectRequestOptions? options = null,
            CancellationToken ct = default);
        public Task<UploadObjectResponse> UploadStreamAsync(
            string objectKey,
            Stream contentStream,
            UploadObjectRequestOptions? options = null,
            CancellationToken ct = default);
        public Task<UploadObjectResponse> UploadStringAsync(
            string objectKey,
            string content,
            UploadObjectRequestOptions? options = null,
            CancellationToken ct = default);
        public Task<UploadObjectResponse> UploadBytesAsync(
            string objectKey,
            byte[] contentBytes,
            UploadObjectRequestOptions? options = null,
            CancellationToken ct = default);
    }
}