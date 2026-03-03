
namespace StratusSDK
{
    /// <summary>
    /// Main entry point for the Stratus SDK.
    /// Provides methods to interact with Zoho Catalyst Stratus cloud storage services.
    /// </summary>
    /// <remarks>
    /// This SDK provides a comprehensive set of operations for managing buckets and objects in Zoho Catalyst Stratus,
    /// including upload, download, copy, rename, delete, and metadata operations.
    /// Initialize the SDK using <see cref="StratusSDKFactory"/> with <see cref="StratusOptions"/>.
    /// </remarks>
    /// <seealso cref="IStratusSDK"/>
    /// <seealso cref="StratusOptions"/>
    public sealed class StratusSDK(OperationResolver resolver) : IStratusSDK
    {
        /// <summary>
            /// Copies an object from one location to another within the bucket.
            /// </summary>
            /// <param name="objectKey">The source object key to copy from.</param>
            /// <param name="destination">The destination key where the object will be copied to.</param>
            /// <param name="ct">Cancellation token to cancel the operation.</param>
            /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="CopyObjectResponse"/>.</returns>
            /// <exception cref="StratusException">Thrown when the API request fails.</exception>
            public Task<CopyObjectResponse> CopyObjectAsync(
            string objectKey,
            string destination,
            CancellationToken ct = default)
            => Op<CopyObjectOperation>().ExecuteAsync(
                new()
                {
                    ObjectKey = new ObjectKey(objectKey),
                    Destination = destination,
                }, ct);

        /// <summary>
        /// Creates a signature for the bucket to enable secure access.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="CreateBucketSignatureResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<CreateBucketSignatureResponse> CreateBucketSignatureAsync(
            CancellationToken ct = default)
            => Op<CreateBucketSignatureOperation>().ExecuteAsync(ct);

        /// <summary>
        /// Deletes one or more objects from the bucket.
        /// </summary>
        /// <param name="request">The <see cref="DeleteObjectRequest"/> containing object keys to delete.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="DeleteObjectResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<DeleteObjectResponse> DeleteObjectAsync(
            string objectKey,
            string? versionId = null,
            int? ttlInSeconds = null,
            CancellationToken ct = default)
            => Op<DeleteObjectOperation>().ExecuteAsync(new()
            {
                Objects =
                [
                    new()
                    {
                        Key = objectKey,
                        VersionId = versionId,
                    }
                ],
                TtlInSeconds = ttlInSeconds,
            }, ct);

        public Task<DeleteObjectResponse> DeleteObjectsAsync(
            List<DeleteObjectRequestData> objectKeys, 
            int? ttlInSeconds = null, 
            CancellationToken ct = default)
            => Op<DeleteObjectOperation>().ExecuteAsync(new()
            {
                Objects = objectKeys,
                TtlInSeconds = ttlInSeconds,
            }, ct);

        public Task<DeleteObjectResponse> DeleteObjectsAsync(List<string> objectKeys, int? ttlInSeconds = null, CancellationToken ct = default)
            => Op<DeleteObjectOperation>().ExecuteAsync(new()
            {
                Objects = objectKeys.Select(key => new DeleteObjectRequestData { Key = key }).ToList(),
                TtlInSeconds = ttlInSeconds,
            }, ct);

        /// <summary>
        /// Deletes all objects matching a specified prefix (path) in the bucket.
        /// </summary>
        /// <param name="prefix">The prefix path to delete all objects under.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="DeletePathResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<DeletePathResponse> DeletePathAsync(
            string prefix,
            CancellationToken ct = default)
            => Op<DeletePathOperation>().ExecuteAsync(prefix, ct);

        /// <summary>
        /// Downloads an object from the bucket.
        /// </summary>
        /// <param name="request">The <see cref="DownloadObjectRequest"/> containing object key and optional version information.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="DownloadObjectResponse"/> containing object data.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<DownloadObjectResponse> DownloadObjectAsync(
            DownloadObjectRequest request,
            CancellationToken ct = default)
            => Op<DownloadObjectOperation>().ExecuteAsync(request, ct);

        /// <summary>
        /// Checks if the configured bucket exists.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="ExistsBucketResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<ExistsBucketResponse> ExistsBucketAsync(CancellationToken ct = default)
            => Op<ExistsBucketOperation>().ExecuteAsync(ct);

        /// <summary>
        /// Checks if a specific object exists in the bucket.
        /// </summary>
        /// <param name="objectKey">The object key to check.</param>
        /// <param name="versionId">Optional version ID to check a specific version.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="ExistsObjectResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<ExistsObjectResponse> ExistsObjectAsync(
            string objectKey,
            string? versionId = null,
            CancellationToken ct = default)
            => Op<ExistsObjectOperation>().ExecuteAsync(
                new()
                {
                    ObjectKey = new ObjectKey(objectKey),
                    VersionId = versionId,
                }, ct);

        /// <summary>
        /// Extracts a zipped object in the bucket to a specified destination.
        /// </summary>
        /// <param name="objectKey">The object key of the ZIP file to extract.</param>
        /// <param name="destination">The destination path for the extracted contents.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="ExtractZipObjectResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<ExtractZipObjectResponse> ExtractZipObjectAsync(
            string objectKey,
            string destination,
            CancellationToken ct = default)
            => Op<ExtractZipObjectOperation>().ExecuteAsync(
                new()
                {
                    ObjectKey = new ObjectKey(objectKey),
                    Destination = destination,
                }, ct);

        /// <summary>
        /// Retrieves bucket information and metadata.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="GetBucketResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<GetBucketResponse> GetBucketAsync(CancellationToken ct = default)
            => Op<GetBucketsOperation>().ExecuteAsync(ct);

        /// <summary>
        /// Gets the status of a zip extraction operation.
        /// </summary>
        /// <param name="objectKey">The object key of the ZIP file being extracted.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="GetStatusOfZipExtractResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<GetStatusOfZipExtractResponse> GetExtractionStatusAsync(
            string taskId,
            CancellationToken ct = default)
            => Op<GetStatusOfZipExtractOperation>().ExecuteAsync(
                new() 
                { 
                    TaskId = taskId,
                }, ct);

        /// <summary>
        /// Retrieves metadata and information about a specific object.
        /// </summary>
        /// <param name="objectKey">The object key to retrieve metadata for.</param>
        /// <param name="versionId">Optional version ID to get metadata for a specific version.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="GetObjectResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<GetObjectResponse> GetObjectAsync(
            string objectKey,
            string? versionId,
            CancellationToken ct = default)
            => Op<GetObjectOperation>().ExecuteAsync(
                new()
                {
                    ObjectKey = new ObjectKey(objectKey),
                    VersionId = versionId,
                }, ct);

        /// <summary>
        /// Retrieves all versions of a specific object.
        /// </summary>
        /// <param name="objectKey">The object key to list versions for.</param>
        /// <param name="maxVersion">Optional maximum number of versions to return.</param>
        /// <param name="continuationToken">Optional pagination token from a previous response.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="GetAllObjectVersionsResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<GetAllObjectVersionsResponse> GetObjectVersionsAsync(
            string objectKey,
            int? maxVersion = null,
            string? continuationToken = null,
            CancellationToken ct = default)
            => Op<GetAllObjectVersionsOperation>().ExecuteAsync(new()
            {
                ObjectKey = new ObjectKey(objectKey),
                MaxVersions = maxVersion,
                ContinuationToken = continuationToken,
            }, ct);

        /// <summary>
        /// Generates a presigned URL for uploading or downloading an object without authentication.
        /// </summary>
        /// <param name="Type">The type of presigned URL to generate (Upload or Download).</param>
        /// <param name="objectKey">The object key to generate the URL for.</param>
        /// <param name="options">Optional settings including expiration, activation time, and version ID.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="PresignedURLResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<PresignedURLResponse> GetPresignedURLAsync(
            EPresignedType Type,
            string objectKey,
            PresignedUrlOptions? options = null,
            CancellationToken ct = default)
            => Op<PresignedUrlOperation>().ExecuteAsync(new()
            {
                ObjectKey = new ObjectKey(objectKey),
                Type = Type,
                ExpireSeconds = options?.ExpireSeconds,
                ActiveFrom = options?.ActiveFrom,
                VersionId = options?.VersionId,
            }, ct);

        /// <summary>
        /// Lists all buckets available in the project.
        /// </summary>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="ListBucketResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<ListBucketResponse> ListAllBucketsAsync(
            CancellationToken ct = default)
            => Op<ListBucketOperation>().ExecuteAsync(ct);

        /// <summary>
        /// Lists all objects in the bucket with optional filtering and pagination.
        /// </summary>
        /// <param name="MaxKeys">Optional maximum number of results per page.</param>
        /// <param name="ContinuationToken">Optional pagination token from a previous response.</param>
        /// <param name="Prefix">Optional prefix to filter objects by key path.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="ListAllObjectsResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<ListAllObjectsResponse> ListAllObjectsAsync(
            int? MaxKeys,
            string? ContinuationToken,
            string? Prefix,
            CancellationToken ct = default)
            => Op<ListAllObjectsOperation>().ExecuteAsync(new()
            {
                MaxKeys = MaxKeys,
                ContinuationToken = ContinuationToken,
                Prefix = Prefix,
            }, ct);

        /// <summary>
        /// Updates custom metadata on an existing object.
        /// </summary>
        /// <param name="objectKey">The object key to update metadata for.</param>
        /// <param name="content">The metadata key-value pairs to set.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="PutObjectMetadataResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<PutObjectMetadataResponse> PutObjectMetadataAsync(
            string objectKey,
            PutObjectMetadataRequestBody content, 
            CancellationToken ct = default)
            => Op<PutObjectMetadataOperation>().ExecuteAsync(new()
            {
                ObjectKey = new ObjectKey(objectKey),
                Body = content,
            }, ct);

        /// <summary>
        /// Renames an object in the bucket.
        /// </summary>
        /// <param name="currentKey">The current object key to rename.</param>
        /// <param name="renameTo">The new object key.</param>
        /// <param name="ct">Cancellation token to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation with <see cref="RenameObjectResponse"/>.</returns>
        /// <exception cref="StratusException">Thrown when the API request fails.</exception>
        public Task<RenameObjectResponse> RenameObjectAsync(
            string currentKey,
            string renameTo,
            CancellationToken ct = default)
            => Op<RenameObjectOperation>().ExecuteAsync(
                new()
                {
                    CurrentKey = currentKey,
                    RenameTo = renameTo,
                }, ct);

        public Task<UploadObjectResponse> UploadAsync(
            string objectKey, 
            IStratusHttpContent content, 
            EContentType contentType = EContentType.TextPlain, 
            UploadObjectRequestOptions? options = null, 
            CancellationToken ct = default)
            => Op<UploadObjectOperation>().ExecuteAsync(new()
            {
                ObjectKey = new ObjectKey(objectKey),
                Content = content,
                HeaderOptions = options?.HeaderOptions,
                VersionId = options?.VersionId,
            }, ct);


        T Op<T>() where T : BaseOperation => resolver.Resolve<T>();

    }
}