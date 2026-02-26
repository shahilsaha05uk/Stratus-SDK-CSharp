using Microsoft.Extensions.DependencyInjection;
using StratusSDK.Api.Bucket.ExistsBucket;

namespace StratusSDK
{
    public static class AllOperationExtension
    {
        public static IServiceCollection AddAllOperations(this IServiceCollection services)
        {
            services.AddScoped<OperationResolver, DIResolver>();

            // Register Operations

            // -- Copy Object Operation --
            services.AddOperation<CopyObjectOperation>();
            services.AddQueryOptions<CopyObjectQueryOptions>();

            // -- Create Bucket Signature Operation --
            services.AddOperation<CreateBucketSignatureOperation>();
            services.AddQueryOptions<CreateBucketSignatureQueryOptions>();

            // -- Delete Object Operation --
            services.AddOperation<DeleteObjectOperation>();
            services.AddQueryOptions<DeleteObjectQueryOptions>();

            // -- Delete Path Operation --
            services.AddOperation<DeletePathOperation>();
            services.AddQueryOptions<DeletePathQueryOptions>();

            // -- Download Object Operation --
            services.AddOperation<DownloadObjectOperation>();
            services.AddQueryOptions<DownloadObjectQueryOptions>();

            // -- Exists Bucket Operation --
            services.AddOperation<ExistsBucketOperation>();
            services.AddQueryOptions<ExistsBucketQueryOptions>();

            // -- Exists Object Operation --
            services.AddOperation<ExistsObjectOperation>();
            services.AddQueryOptions<ExistsObjectQueryOptions>();

            // -- Extract Zip Object Operation --
            services.AddOperation<ExtractZipObjectOperation>();
            services.AddQueryOptions<ExtractZipObjectQueryOptions>();

            // -- Get All Objects Operation --
            services.AddOperation<ListAllObjectsOperation>();
            services.AddQueryOptions<ListAllObjectsQueryOptions>();

            // -- Get All Object Versions Operation --
            services.AddOperation<GetAllObjectVersionsOperation>();
            services.AddQueryOptions<GetAllObjectVersionsQueryOptions>();

            // -- Get Buckets Operation --
            services.AddOperation<GetBucketsOperation>();
            services.AddQueryOptions<GetBucketQueryOptions>();

            // -- Get Object Operation --
            services.AddOperation<GetObjectOperation>();
            services.AddQueryOptions<GetObjectQueryOptions>();

            // -- Get Status Of Zip Extract Operation --
            services.AddOperation<GetStatusOfZipExtractOperation>();
            services.AddQueryOptions<GetStatusOfZipExtractQueryOptions>();

            // -- List Bucket Operation --
            services.AddOperation<ListBucketOperation>();

            // -- Presigned Url Operation --
            services.AddOperation<PresignedUrlOperation>();
            services.AddQueryOptions<PresignedUrlQueryOptions>();

            // -- Put Object Metadata Operation --
            services.AddOperation<PutObjectMetadataOperation>();
            services.AddQueryOptions<PutObjectMetadataQueryOptions>();

            // -- Rename Object Operation --
            services.AddOperation<RenameObjectOperation>();
            services.AddQueryOptions<RenameObjectQueryOptions>();

            // -- Upload Object Operation --
            services.AddOperation<UploadObjectOperation>();
            services.AddQueryOptions<UploadObjectQueryOptions>();

            return services;
        }
    }
}