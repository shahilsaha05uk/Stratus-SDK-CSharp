// ============================================================================
// Stratus SDK - Sample Controller (Dependency Injection)
// ============================================================================
//
// This is a sample ASP.NET Core controller demonstrating how each of the
// Stratus SDK operations can be used with dependency injection.
//
// To use this in your own .NET project:
//   1. Copy this file into your project.
//   2. Install the Stratus SDK NuGet package.
//   3. In your Program.cs, register the Stratus SDK services:
//
//        builder.Services.AddStratusExtensions(options =>
//        {
//            options.BucketName   = "your-bucket-name";
//            options.ProjectID    = "your-project-id";
//            options.Region       = ERegion.US;
//            options.ClientID     = "your-client-id";
//            options.ClientSecret = "your-client-secret";
//            options.RefreshToken = "your-refresh-token";
//            options.RedirectUrl  = "your-redirect-url";
//        });
//
//   4. Inject IStratusSDK (and optionally ITokenManager) into your controllers
//      or services as shown below.
//
// ============================================================================

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StratusSDK.Samples
{
    [Route("stratus")]
    [Tags("Stratus SDK Test")]
    [ApiController]
    public class StratusController(
        IStratusSDK stratus,
        ITokenManager tokenManager) : ControllerBase
    {
        public string? TaskId { get; set; }

        [HttpGet("object/copy")]
        [EndpointSummary("Copy Object")]
        public async Task<IActionResult> CopyObject()
        {
            var sourceKey = "pdf-test-2-renamed.pdf";
            var destinationKey = "pdfs/pdf-test-2.pdf";
            var response = await stratus.CopyObjectAsync(new(sourceKey), destinationKey);
            return Ok(response);
        }

        [HttpGet("create/bucket-signature")]
        [EndpointSummary("Create Bucket Signature")]
        public async Task<IActionResult> CreateBucketSignature()
        {
            var response = await stratus.CreateBucketSignatureAsync();
            return Ok(response);
        }

        [HttpGet("object/delete")]
        [EndpointSummary("Delete Object")]
        public async Task<IActionResult> DeleteObject()
        {
            var objectKey = new ObjectKey("pdf-test-2-renamed.pdf");
            var response = await stratus.DeleteObjectAsync(objectKey);
            return Ok(response);
        }

        [HttpGet("objects/delete")]
        [EndpointSummary("Delete Objects")]
        public async Task<IActionResult> DeleteObjects()
        {
            var response = await stratus.DeleteObjectsAsync(
                new List<DeleteObjectRequestData>
                {
                    new()
                    {
                        Key = "pdf-test-2-renamed.pdf",
                    }
                });

            return Ok(response);
        }

        [HttpGet("path/delete")]
        [EndpointSummary("Delete Path")]
        public async Task<IActionResult> DeletePath()
        {
            var response = await stratus.DeletePathAsync("unzipped/");
            return Ok(response);
        }

        [HttpGet("object/download")]
        [EndpointSummary("Download")]
        public async Task<IActionResult> DownloadObject()
        {
            var objectKey = "pdf-test-2.pdf";
            var contentType = EContentType.ApplicationPdf;

            var response = await stratus.DownloadObjectAsync(new()
            {
                ObjectKey = objectKey,
                OverridingQueryOptions = new()
                {
                    ResponseContentType = contentType
                }
            });

            if (response.Data is null)
            {
                return NotFound(new
                {
                    Message = "Object not found or empty."
                });
            }

            return File(
                response.Data,
                contentType.ToMimeString(),
                objectKey);
        }

        [HttpGet("bucket/exists")]
        [EndpointSummary("Bucket Exists?")]
        public async Task<IActionResult> ExistsBucket()
        {
            var response = await stratus.ExistsBucketAsync();
            return Ok(response);
        }

        [HttpGet("object/exists")]
        [EndpointSummary("Object Exists?")]
        public async Task<IActionResult> ExistsObject()
        {
            var objectKey = "pdf-test-2.pdf";
            var response = await stratus.ExistsObjectAsync(new(objectKey));
            return Ok(response);
        }

        [HttpGet("object/extract")]
        [EndpointSummary("Extract a zip file")]
        public async Task<IActionResult> ExtractObject()
        {
            var objectKey = "test.zip";

            var response = await stratus.ExtractZipObjectAsync(
                new ObjectKey(objectKey),
                "unzipped/");

            TaskId = response.Data.TaskId;
            return Ok(response);
        }

        [HttpGet("bucket")]
        [EndpointSummary("Get Bucket")]
        public async Task<IActionResult> GetBucket()
        {
            var response = await stratus.GetBucketAsync();
            return Ok(response);
        }

        [HttpGet("buckets/all")]
        [EndpointSummary("Get All Buckets")]
        public async Task<IActionResult> GetBuckets()
        {
            var buckets = await stratus.ListAllBucketsAsync();
            return Ok(buckets);
        }

        [HttpGet("object/extract/status")]
        [EndpointSummary("Check Extraction Status")]
        public async Task<IActionResult> GetExtractStatus()
        {
            if (TaskId is not null)
            {
                var response = await stratus.GetExtractionStatusAsync(TaskId);

                if (response.Data.Status is EZipExtractStatus.COMPLETED)
                {
                    TaskId = null;

                    return Ok(new
                    {
                        Message = "No extraction task initiated. Please call /object/extract endpoint first."
                    });
                }

                return Ok(response);
            }

            return Ok(new
            {
                Message = "No extraction task initiated. Please call /object/extract endpoint first."
            });
        }

        [HttpGet("object")]
        [EndpointSummary("Get Object")]
        public async Task<IActionResult> GetObject()
        {
            var objectKey = "pdf-test-2.pdf";
            var response = await stratus.GetObjectAsync(objectKey);
            return Ok(response);
        }

        [HttpGet("objects/all")]
        [EndpointSummary("Get All Objects")]
        public async Task<IActionResult> GetObjects()
        {
            var objects = await stratus.ListAllObjectsAsync();
            return Ok(objects);
        }

        [HttpGet("object/versions")]
        [EndpointSummary("Get Object Versions")]
        public async Task<IActionResult> GetObjectVersions()
        {
            var objectKey = "pdf-test-2.pdf";
            var response = await stratus.GetObjectVersionsAsync(new(objectKey));
            return Ok(response);
        }

        [HttpGet("presigned-url/download")]
        [EndpointSummary("Get Presigned Download Link")]
        public async Task<IActionResult> GetPresignedDownloadUrl()
        {
            var objectKey = "pdfs/pdf-test-2.pdf";

            var response = await stratus.GetPresignedURLAsync(
                EPresignedType.Download,
                new ObjectKey(objectKey),
                new()
                {
                    ExpireSeconds = 360, // 1 hour
                });

            return Ok(response);
        }

        [HttpGet("presigned-url/upload")]
        [EndpointSummary("Get Presigned Upload Link")]
        public async Task<IActionResult> GetPresignedUploadUrl()
        {
            var objectKey = "pdfs/pdf-test-2.pdf";

            var response = await stratus.GetPresignedURLAsync(
                EPresignedType.Upload,
                new ObjectKey(objectKey),
                new()
                {
                    ExpireSeconds = 360, // 1 hour
                });

            return Ok(response);
        }

        [HttpGet("token")]
        [EndpointSummary("Generate access token")]
        public async Task<IActionResult> GetStratusToken()
        {
            var token = await tokenManager.GetToken();
            return Ok(token);
        }

        [HttpGet("object/put-metadata")]
        [EndpointSummary("Put Object Metadata")]
        public async Task<IActionResult> PutObjectMetadata()
        {
            var objectKey = "pdf-test-2.pdf";

            var response = await stratus.PutObjectMetadataAsync(new(objectKey), new()
            {
                Metadata = new()
                {
                    { "Author", "Shahil" },
                    { "Description", "This is a test PDF file." }
                },
            });

            return Ok(response);
        }

        [HttpGet("object/rename")]
        [EndpointSummary("Rename Object")]
        public async Task<IActionResult> RenameObject()
        {
            var currentKey = "pdf-test-2.pdf";
            var renameTo = "pdf-test-2-renamed.pdf";
            var response = await stratus.RenameObjectAsync(new(currentKey), renameTo);
            return Ok(response);
        }

        [HttpGet("object/upload")]
        [EndpointSummary("Upload Object")]
        public async Task<IActionResult> UploadObject()
        {
            var filePath = "/path/to/local/pdf-test-2.pdf";
            var objectKey = "pdf-test-2.pdf";

            var response = await stratus.UploadFileAsync(
                new ObjectKey(objectKey),
                filePath,
                EContentType.ApplicationPdf);

            return Ok(response);
        }

        [HttpGet("object/upload-zip")]
        [EndpointSummary("Upload Zip file")]
        public async Task<IActionResult> UploadZipObject()
        {
            var filePath = "/path/to/local/test.zip";
            var objectKey = "test.zip";

            var response = await stratus.UploadFileAsync(
                new ObjectKey(objectKey),
                filePath,
                EContentType.ApplicationZip);

            return Ok(response);
        }
    }
}
