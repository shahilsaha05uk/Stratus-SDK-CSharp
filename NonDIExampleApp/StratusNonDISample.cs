// ============================================================================
// Stratus SDK - Sample Usage Without Dependency Injection
// ============================================================================
//
// This sample demonstrates how to use the Stratus SDK without a DI container.
// Use StratusSDKFactory.Create() to instantiate the SDK manually with your
// configuration options, then call operations directly.
//
// This approach is ideal for console apps, scripts, background workers, or
// any scenario where a DI container is not available.
//
// ============================================================================

namespace StratusSDK.Samples
{
    public class StratusNonDISample
    {
        private const string PdfFilePath = "D:\\SideProjects\\TestApp\\assets\\pdf-test.pdf";
        private const string ZipFilePath = "D:\\SideProjects\\TestApp\\assets\\test.zip";
        private const string UploadFilePath = "D:\\SideProjects\\TestApp\\assets\\upload-test-file.txt";

        private IStratusSDK CreateSDK()
        {
            var options = new StratusOptions
            {
                BucketName = "your-bucket-name",
                ProjectID = "your-project-id",
                Region = ERegion.US,
                // Environment defaults to Development; override if needed:
                // Environment = EStratusEnvironment.Production,
                ClientID = "your-client-id",
                ClientSecret = "your-client-secret",
                RefreshToken = "your-refresh-token",
                RedirectUrl = "your-redirect-url",
            };

            return StratusSDKFactory.Create(options);
        }

        public async Task CopyObjectAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.CopyObjectAsync("source-file.pdf", "destination/source-file.pdf");
            Console.WriteLine(response);
        }

        public async Task CreateBucketSignatureAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.CreateBucketSignatureAsync();
            Console.WriteLine(response);
        }

        public async Task DeleteObjectAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.DeleteObjectAsync("file-to-delete.pdf");
            Console.WriteLine(response);
        }

        public async Task DeleteObjectsAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.DeleteObjectsAsync(
            [
                "file-1.pdf",
                "file-2.pdf",
            ]);
            Console.WriteLine(response);
        }

        public async Task DeletePathAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.DeletePathAsync("folder-to-delete/");
            Console.WriteLine(response);
        }

        public async Task DownloadObjectAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.DownloadObjectAsync(new DownloadObjectRequest
            {
                ObjectKey = "pdf-test.pdf",
                OverridingQueryOptions = new()
                {
                    ResponseContentType = EContentType.ApplicationPdf
                }
            });

            if (response.Data is not null)
            {
                await File.WriteAllBytesAsync("downloaded-file.pdf", response.Data);
                Console.WriteLine("File downloaded successfully.");
            }
        }

        public async Task ExistsBucketAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.ExistsBucketAsync();
            Console.WriteLine($"Bucket exists: {response}");
        }

        public async Task ExistsObjectAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.ExistsObjectAsync("pdf-test.pdf");
            Console.WriteLine($"Object exists: {response}");
        }

        public async Task ExtractZipObjectAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.ExtractZipObjectAsync("archive.zip", "extracted/");
            Console.WriteLine($"Extraction task ID: {response.Data.TaskId}");
        }

        public async Task GetBucketAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.GetBucketAsync();
            Console.WriteLine(response);
        }

        public async Task GetExtractionStatusAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.GetExtractionStatusAsync("your-task-id");
            Console.WriteLine($"Extraction status: {response.Data.Status}");
        }

        public async Task GetObjectAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.GetObjectAsync("pdf-test.pdf");
            Console.WriteLine(response);
        }

        public async Task GetObjectVersionsAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.GetObjectVersionsAsync("pdf-test.pdf");
            Console.WriteLine(response);
        }

        public async Task GetPresignedDownloadUrlAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.GetPresignedURLAsync(
                EPresignedType.Download,
                "pdf-test.pdf",
                new PresignedUrlOptions
                {
                    ExpireSeconds = 3600,
                });
            Console.WriteLine($"Download URL: {response}");
        }

        public async Task GetPresignedUploadUrlAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.GetPresignedURLAsync(
                EPresignedType.Upload,
                "pdf-test.pdf",
                new PresignedUrlOptions
                {
                    ExpireSeconds = 3600,
                });
            Console.WriteLine($"Upload URL: {response}");
        }

        public async Task ListAllBucketsAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.ListAllBucketsAsync();
            Console.WriteLine(response);
        }

        public async Task ListAllObjectsAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.ListAllObjectsAsync();
            Console.WriteLine(response);
        }

        public async Task PutObjectMetadataAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.PutObjectMetadataAsync("pdf-test.pdf", new PutObjectMetadataRequestBody
            {
                Metadata = new()
                {
                    { "Author", "Shahil" },
                    { "Description", "This is a test PDF file." }
                },
            });
            Console.WriteLine(response);
        }

        public async Task RenameObjectAsync()
        {
            var stratus = CreateSDK();
            var response = await stratus.RenameObjectAsync("old-name.pdf", "new-name.pdf");
            Console.WriteLine(response);
        }

        public async Task UploadByFilePath()
        {
            var stratus = CreateSDK();

            var objectKey = "pdf-test-2.pdf";

            var response = await stratus.UploadAsync(
                objectKey,
                UploadContent.FromFile(PdfFilePath),
                EContentType.ApplicationPdf);
        }

        public async Task UploadByString()
        {
            var stratus = CreateSDK();

            var objectKey = "pdf-test-2.pdf";

            var response = await stratus.UploadAsync(
                objectKey,
                UploadContent.FromString("Hello World!!"));
        }

        public async Task UploadZipObject()
        {
            var stratus = CreateSDK();
            var objectKey = "test.zip";
            var buffer = await System.IO.File.ReadAllBytesAsync(ZipFilePath);
            var response = await stratus.UploadAsync(
                objectKey,
                UploadContent.FromBytes(buffer),
                EContentType.ApplicationZip);
        }

        public async Task UploadFileAsStream()
        {
            var stratus = CreateSDK();
            var objectKey = "pdf-test-2.pdf";
            var response = await stratus.UploadAsync(
                objectKey,
                UploadContent.FromStream(() => System.IO.File.OpenRead(UploadFilePath)));
        }
    }
}
