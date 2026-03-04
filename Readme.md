# Stratus SDK for .NET

Nuget Package Link: https://www.nuget.org/packages/CSharp.StratusSDK

A comprehensive .NET SDK for interacting with Zoho Catalyst Stratus cloud storage. Provides easy-to-use APIs for managing buckets, uploading/downloading objects, and performing advanced storage operations.

[![.NET](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [SDK Initialization](#sdk-initialization)
  - [Option 1: Dependency Injection (ASP.NET Core)](#option-1-dependency-injection-recommended-for-aspnet-core)
  - [Option 2: Manual Initialization (Console Apps)](#option-2-manual-initialization-for-console-apps--non-di-scenarios)
  - [Exception Handler (DI Only)](#exception-handler-di-only)
  - [Choosing Between Patterns](#choosing-between-patterns)
- [Samples](#samples)
- [Quick Start](#quick-start)
- [Configuration](#configuration)
  - [Required Settings](#required-settings)
  - [Regions](#regions)
- [Usage Examples](#usage-examples)
  - [Check Object Existence](#check-object-existence)
  - [Copy Objects](#copy-objects)
  - [Delete Objects](#delete-objects)
  - [Download Specific Version](#download-specific-version)
  - [Extract ZIP Files](#extract-zip-files)
  - [Generate Presigned URLs](#generate-presigned-urls)
  - [List Objects with Pagination](#list-objects-with-pagination)
  - [Rename Objects](#rename-objects)
  - [Upload](#upload)
- [Data Models Reference](#data-models-reference)
  - [Configuration](#configuration-1)
    - [StratusOptions](#stratusoptions)
  - [Request Models](#request-models)
    - [DeleteObjectRequestData](#deleteobjectrequestdata)
    - [DownloadHeaderOptions](#downloadheaderoptions)
    - [DownloadObjectRequest](#downloadobjectrequest)
    - [PresignedUrlOptions](#presignedurloptions)
    - [PutObjectMetadataRequestBody](#putobjectmetadatarequestbody)
    - [UploadContent](#uploadcontent)
    - [UploadHeaderOptions](#uploadheaderoptions)
    - [UploadObjectRequestOptions](#uploadobjectrequest-options)
  - [Response Models](#response-models-1)
    - [Bucket](#bucket)
    - [BucketObject](#bucketobject)
    - [CreateBucketSignatureData](#createbucketsignaturedata)
    - [CreateBucketSignatureResponse](#createbucketsignatureresponse)
    - [DownloadObjectResponse](#downloadobjectresponse)
    - [GetAllObjectResponseData](#getallobjectresponsedata)
    - [GetAllObjectsResponse](#getallobjectsresponse)
    - [GetStatusOfZipExtractData](#getstatusofzipextractdata)
    - [GetStatusOfZipExtractResponse](#getstatusofzipextractresponse)
    - [PresignedUrlData](#presignedurldata)
    - [PresignedURLResponse](#presignedurlresponse)
  - [Enumerations](#enumerations)
    - [ECachingStatus](#ecachingstatus)
    - [EContentType](#econtenttype)
    - [EPresignedType](#epresignedtype)
    - [ERegion](#eregion)
    - [EStratusKeyType](#estratuskeytype)
    - [EZipExtractStatus](#ezipextractstatus)
  - [Interfaces](#interfaces)
    - [IStratusSDK](#istratussdk)
- [API Reference](#api-reference)
  - [Object Operations](#object-operations)
    - [CopyObjectAsync](#copyobjectasync)
    - [DeleteObjectAsync](#deleteobjectasync)
    - [DeleteObjectsAsync](#deleteobjectsasync)
    - [DeletePathAsync](#deletepathasync)
    - [DownloadObjectAsync](#downloadobjectasync)
    - [ExistsObjectAsync](#existsobjectasync)
    - [RenameObjectAsync](#renameobjectasync)
    - [UploadAsync](#uploadasync)
  - [Metadata & Information](#metadata--information)
    - [GetObjectAsync](#getobjectasync)
    - [GetObjectVersionsAsync](#getobjectversionsasync)
    - [ListAllObjectsAsync](#listallobjectsasync)
    - [PutObjectMetadataAsync](#putobjectmetadataasync)
  - [Bucket Operations](#bucket-operations)
    - [CreateBucketSignatureAsync](#createbucketsignatureasync)
    - [ExistsBucketAsync](#existsbucketasync)
    - [GetBucketAsync](#getbucketasync)
    - [ListAllBucketsAsync](#listallbucketsasync)
  - [Advanced Operations](#advanced-operations)
    - [ExtractZipObjectAsync](#extractzipobjectasync)
    - [GetExtractionStatusAsync](#getextractionstatusasync)
    - [GetPresignedURLAsync](#getpresignedurlasync)
- [Error Handling](#error-handling)
  - [StratusException](#stratusexception)
  - [StratusAuthenticationException](#stratusauthenticationexception)
- [Operation Stability](#operation-stability)
  - [Stable Operations](#stable-operations)
  - [Experimental Operations](#experimental-operations)
- [Known Limitations & Improvements](#known-limitations--improvements)
- [Best Practices](#best-practices)
- [Advanced Configuration](#advanced-configuration)
  - [Upload Options](#upload-options)
  - [Download Options](#download-options)
- [Performance Tips](#performance-tips)
- [Troubleshooting](#troubleshooting)
  - [Common Issues](#common-issues)
- [Requirements](#requirements)
- [Support](#support)
- [License](#license)
- [Contributing](#contributing)
- [Changelog](#changelog)

## Features

✨ **Object Management**
- Upload and download files with metadata
- Copy, rename, and delete objects
- Version control support
- Automatic compression

🔐 **Security**
- OAuth 2.0 authentication
- Presigned URLs for temporary access
- Secure credential management

📦 **Bucket Operations**
- List and manage buckets
- Bucket metadata and configuration
- Multi-region support

🚀 **Advanced Features**
- ZIP file extraction in cloud
- Pagination support for large listings
- Custom metadata for objects
- Automatic retry and error handling

## Installation

Install the StratusSDK package via NuGet:

```bash
dotnet add package StratusSDK
```

Or via Package Manager Console:

```powershell
Install-Package StratusSDK
```

## SDK Initialization

The SDK supports two initialization patterns depending on your use case:

### Option 1: Dependency Injection (Recommended for ASP.NET Core)

**Use Case:** ASP.NET Core applications, Web APIs, Blazor apps

**Benefits:**
- Automatic lifetime management
- Built-in exception handling middleware
- Better testability with interfaces
- Integration with ASP.NET Core logging
- Proper HttpClient management

**Setup:**

```csharp
using StratusSDK;

var builder = WebApplication.CreateBuilder(args);

// Add Stratus SDK with DI
builder.Services.AddStratusExtensions(options =>
{
    options.BucketName = "your-bucket-name";
    options.ProjectID = "your-project-id";
    options.Region = ERegion.US;
    options.Environment = EStratusEnvironment.Production; // Defaults to Development; override for production
    options.ClientID = builder.Configuration["Stratus:ClientID"];
    options.ClientSecret = builder.Configuration["Stratus:ClientSecret"];
    options.RefreshToken = builder.Configuration["Stratus:RefreshToken"];
    options.RedirectUrl = builder.Configuration["Stratus:RedirectUrl"];
});

// Optional: Add Stratus Exception Handler for automatic error handling
builder.Services.AddExceptionHandler<StratusExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Enable exception handling middleware
app.UseExceptionHandler();

app.MapControllers();
app.Run();
```

**Usage in Controllers/Services:**

```csharp
using StratusSDK;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly IStratusSDK _sdk;
    private readonly ILogger<FilesController> _logger;

    // SDK is injected automatically
    public FilesController(IStratusSDK sdk, ILogger<FilesController> logger)
    {
        _sdk = sdk;
        _logger = logger;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        using var stream = file.OpenReadStream();

        // Exceptions are automatically handled by StratusExceptionHandler
        await _sdk.UploadAsync(
            $"uploads/{file.FileName}",
            UploadContent.FromStream(stream));

        return Ok(new { message = "File uploaded successfully" });
    }
}
```

**Configuration in appsettings.json:**

```json
{
  "Stratus": {
    "BucketName": "your-bucket-name",
    "ProjectID": "your-project-id",
    "Region": "US",
    "ClientID": "your-client-id",
    "ClientSecret": "your-client-secret",
    "RefreshToken": "your-refresh-token",
    "RedirectUrl": "your-redirect-url"
  }
}
```

### Option 2: Manual Initialization (For Console Apps & Non-DI Scenarios)

**Use Case:** Console applications, background services, legacy applications

**Benefits:**
- Simple and straightforward
- No DI container required
- Full control over SDK lifecycle
- Suitable for scripts and utilities

**Setup:**

```csharp
using StratusSDK;

var options = new StratusOptions
{
    BucketName = "your-bucket-name",
    ProjectID = "your-project-id",
    Region = ERegion.US,
    // Environment defaults to EStratusEnvironment.Development; override if needed:
    // Environment = EStratusEnvironment.Production,
    ClientID = "your-client-id",
    ClientSecret = "your-client-secret",
    RefreshToken = "your-refresh-token",
    RedirectUrl = "your-redirect-url"
};

var sdk = StratusSDKFactory.Create(options);
```

**Usage:**

```csharp
using StratusSDK;

class Program
{
    static async Task Main(string[] args)
    {
        var options = new StratusOptions
        {
            BucketName = Environment.GetEnvironmentVariable("STRATUS_BUCKET"),
            ProjectID = Environment.GetEnvironmentVariable("STRATUS_PROJECT_ID"),
            Region = ERegion.US,
            // Environment defaults to EStratusEnvironment.Development; override if needed:
            // Environment = EStratusEnvironment.Production,
            ClientID = Environment.GetEnvironmentVariable("STRATUS_CLIENT_ID"),
            ClientSecret = Environment.GetEnvironmentVariable("STRATUS_CLIENT_SECRET"),
            RefreshToken = Environment.GetEnvironmentVariable("STRATUS_REFRESH_TOKEN"),
            RedirectUrl = Environment.GetEnvironmentVariable("STRATUS_REDIRECT_URL")
        };

        var sdk = StratusSDKFactory.Create(options);

        try
        {
            // Upload
            await sdk.UploadAsync(
                "test/file.txt",
                UploadContent.FromString("Hello, Stratus!"));
            Console.WriteLine("Upload successful!");

            // Download
            var response = await sdk.DownloadObjectAsync(new DownloadObjectRequest
            {
                ObjectKey = "test/file.txt"
            });
            Console.WriteLine($"Downloaded {response.Data?.Length ?? 0} bytes");
        }
        catch (StratusException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Status: {ex.StatusCode}");
        }
    }
}
```

### Exception Handler (DI Only)

The `StratusExceptionHandler` provides automatic exception handling for ASP.NET Core applications:

**Features:**
- Automatically catches `StratusException` from any SDK operation
- Converts exceptions to standardized Problem Details (RFC 7807)
- Logs errors with structured data
- Returns proper HTTP status codes
- Includes error codes and details in response

**Registration:**

```csharp
// In Program.cs or Startup.cs
builder.Services.AddExceptionHandler<StratusExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseExceptionHandler(); // Enable exception handling
```

**Response Format:**

When a `StratusException` occurs, the handler returns:

```json
{
  "type": "https://api.catalyst.zoho.com/baas/v1/project/123/bucket/object",
  "title": "Stratus API Error",
  "status": 404,
  "detail": "Object not found: documents/report.pdf",
  "instance": "/api/files/download",
  "errorCode": "OBJECT_NOT_FOUND"
}
```

**Example with Exception Handler:**

```csharp
using StratusSDK;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/storage")]
public class StorageController : ControllerBase
{
    private readonly IStratusSDK _sdk;

    public StorageController(IStratusSDK sdk)
    {
        _sdk = sdk;
    }

    [HttpGet("download/{*objectKey}")]
    public async Task<IActionResult> Download(string objectKey)
    {
        // No try-catch needed - StratusExceptionHandler handles it
        var response = await _sdk.DownloadObjectAsync(new DownloadObjectRequest
        {
            ObjectKey = objectKey
        });

        return File(response.Content, response.ContentType, Path.GetFileName(objectKey));
    }

    [HttpDelete("{*objectKey}")]
    public async Task<IActionResult> Delete(string objectKey)
    {
        // Exceptions are automatically converted to Problem Details
        await _sdk.DeleteObjectAsync(objectKey);

        return NoContent();
    }
}
```

### Choosing Between Patterns

| Feature | DI Pattern | Manual Pattern |
|---------|-----------|----------------|
| **Use Case** | ASP.NET Core, Web APIs | Console apps, Scripts |
| **Setup Complexity** | Medium | Low |
| **Exception Handling** | Automatic (with handler) | Manual try-catch |
| **Testability** | Excellent (interface-based) | Good |
| **HttpClient Management** | Automatic (pooled) | Manual |
| **Logging Integration** | Built-in | Manual |
| **Configuration** | appsettings.json | Environment variables/code |
| **Lifetime Management** | Automatic (scoped) | Manual |

**Recommendation:**
- ✅ **Use DI Pattern** for web applications, APIs, and long-running services
- ✅ **Use Manual Pattern** for console apps, scripts, and simple utilities

## Samples

Ready-to-use examples are available as separate projects in the solution:

- **[`TestApp/`](https://github.com/shahilsaha05uk/Stratus-SDK-CSharp/tree/main/TestApp)** (`DIExampleApp`) — An ASP.NET Core project demonstrating **dependency injection** setup with a full controller (`StratusController.cs`) wired up with Scalar/OpenAPI for interactive testing.
- **[`NonDIExampleApp/`](https://github.com/shahilsaha05uk/Stratus-SDK-CSharp/tree/main/NonDIExampleApp)** — A console application demonstrating how to use the SDK **without a DI container**, using `StratusSDKFactory.Create()`.

Feel free to copy these into your own project as a starting point.

## Quick Start

> **Note:** This quick start uses the manual initialization pattern. For ASP.NET Core applications, see the [Dependency Injection setup](#option-1-dependency-injection-recommended-for-aspnet-core) above.

### 1. Configure the SDK

Create a `StratusOptions` instance with your Zoho Catalyst credentials:

```csharp
using StratusSDK;

var options = new StratusOptions
{
    BucketName = "your-bucket-name",
    ProjectID = "your-project-id",
    Region = ERegion.US,
    // Environment defaults to EStratusEnvironment.Development; override if needed:
    // Environment = EStratusEnvironment.Production,
    ClientID = "your-client-id",
    ClientSecret = "your-client-secret",
    RefreshToken = "your-refresh-token",
    RedirectUrl = "your-redirect-url"
};
```

### 2. Initialize the SDK

```csharp
var sdk = StratusSDKFactory.Create(options);
```

### 3. Start Using

```csharp
// Upload a file from disk
await sdk.UploadAsync(
    "documents/report.pdf",
    UploadContent.FromFile("report.pdf"),
    EContentType.ApplicationPdf);

// Download a file
var response = await sdk.DownloadObjectAsync(new DownloadObjectRequest
{
    ObjectKey = "documents/report.pdf"
});

// List objects
var objects = await sdk.ListAllObjectsAsync(
    Prefix: "documents/");
```

## Configuration

### Required Settings

| Property | Description | Example |
|----------|-------------|---------|
| `BucketName` | Your Stratus bucket name | `"my-storage-bucket"` |
| `ProjectID` | Catalyst project identifier | `"1234567890"` |
| `Region` | Data center region | `ERegion.US` |
| `Environment` | Stratus environment (defaults to `Development`; can be overridden to `Production`) | `EStratusEnvironment.Production` |
| `ClientID` | OAuth client ID | `"1000.XXXXX"` |
| `ClientSecret` | OAuth client secret | `"xxxxxxxxxxxxx"` |
| `RefreshToken` | OAuth refresh token | `"1000.xxxxx.xxxxx"` |
| `RedirectUrl` | OAuth redirect URL | `"https://your-app.com/callback"` |

### Regions

Available regions via `ERegion` enum:

- `ERegion.US` - United States
- `ERegion.EU` - European Union
- `ERegion.IN` - India
- `ERegion.AU` - Australia
- `ERegion.JP` - Japan
- `ERegion.CA` - Canada

## Usage Examples

All examples below are shown in two patterns: **Manual** (for console apps) and **Dependency Injection** (for ASP.NET Core).

### Check Object Existence

**Manual (Console App):**

```csharp
var result = await sdk.ExistsObjectAsync("documents/report.pdf");

if (result.Success)
{
    Console.WriteLine("File exists!");
}
else
{
    Console.WriteLine("File not found.");
}
```

**Dependency Injection (ASP.NET Core):**

```csharp
[HttpHead("{*objectKey}")]
public async Task<IActionResult> CheckExists(string objectKey)
{
    var result = await _sdk.ExistsObjectAsync(objectKey);

    return result.Success ? Ok() : NotFound();
}
```

### Copy Objects

**Manual (Console App):**

```csharp
await sdk.CopyObjectAsync(
    "documents/report.pdf",
    "archive/2024/report.pdf");

Console.WriteLine("File copied successfully");
```

**Dependency Injection (ASP.NET Core):**

```csharp
[HttpPost("copy")]
public async Task<IActionResult> CopyFile([FromBody] CopyRequest copyRequest)
{
    await _sdk.CopyObjectAsync(
        copyRequest.Source,
        copyRequest.Destination);
    return Ok(new { message = "File copied successfully" });
}

public record CopyRequest(string Source, string Destination);
```

### Delete Objects

**Manual (Console App):**

```csharp
// Delete a single object
await sdk.DeleteObjectAsync("temp/file1.txt");

// Delete a single object with version
await sdk.DeleteObjectAsync(
    "temp/file1.txt",
    versionId: "version123");

// Delete multiple objects
await sdk.DeleteObjectsAsync(
    new List<string> { "temp/file1.txt", "temp/file2.txt" });

// Delete multiple objects with detailed control
await sdk.DeleteObjectsAsync(
    new List<DeleteObjectRequestData>
    {
        new() { Key = "temp/file1.txt" },
        new() { Key = "temp/file2.txt", VersionId = "version123" }
    });

Console.WriteLine("Files deleted successfully");
```

**Dependency Injection (ASP.NET Core):**

```csharp
[HttpDelete("{*objectKey}")]
public async Task<IActionResult> Delete(string objectKey)
{
    await _sdk.DeleteObjectAsync(objectKey);
    return NoContent();
}

[HttpDelete("batch")]
public async Task<IActionResult> DeleteMultiple([FromBody] List<string> objectKeys)
{
    await _sdk.DeleteObjectsAsync(objectKeys);
    return NoContent();
}
```

### Download Specific Version

**Manual (Console App):**

```csharp
var request = new DownloadObjectRequest
{
    ObjectKey = "documents/report.pdf",
    VersionId = "01hh9hkfdf07y8pnpbwtkt8cf7"
};

var response = await sdk.DownloadObjectAsync(request);
byte[] fileContent = response.Content;

// Save to file
await File.WriteAllBytesAsync("downloaded-report.pdf", fileContent);
```

**Dependency Injection (ASP.NET Core):**

```csharp
[HttpGet("download/{*objectKey}")]
public async Task<IActionResult> Download(string objectKey, [FromQuery] string? versionId = null)
{
    var request = new DownloadObjectRequest
    {
        ObjectKey = objectKey,
        VersionId = versionId
    };

    var response = await _sdk.DownloadObjectAsync(request);

    return File(
        response.Content, 
        response.ContentType ?? "application/octet-stream",
        Path.GetFileName(objectKey)
    );
}
```

### Extract ZIP Files

**Manual (Console App):**

```csharp
// Start extraction
var extractResponse = await sdk.ExtractZipObjectAsync(
    "archives/data.zip",
    "extracted/data/");

string taskId = extractResponse.Data.TaskId;
Console.WriteLine($"Extraction started. Task ID: {taskId}");

// Poll for status
EZipExtractStatus status;
do
{
    await Task.Delay(2000); // Wait 2 seconds

    var statusResponse = await sdk.GetExtractionStatusAsync(taskId);
    status = statusResponse.Data.Status;
    Console.WriteLine($"Status: {status}");
}
while (status == EZipExtractStatus.PENDING);

if (status == EZipExtractStatus.COMPLETED)
{
    Console.WriteLine("Extraction completed successfully!");
}
else
{
    Console.WriteLine("Extraction failed.");
}
```

**Dependency Injection (ASP.NET Core):**

```csharp
[HttpPost("extract-zip")]
public async Task<IActionResult> ExtractZip([FromBody] ExtractRequest request)
{
    var response = await _sdk.ExtractZipObjectAsync(
        request.ZipPath,
        request.Destination);

    return Accepted(new 
    { 
        taskId = response.Data.TaskId,
        statusEndpoint = $"/api/storage/extract-status?objectKey={request.ZipPath}"
    });
}

[HttpGet("extract-status")]
public async Task<IActionResult> GetExtractionStatus([FromQuery] string taskId)
{
    var response = await _sdk.GetExtractionStatusAsync(taskId);

    return Ok(new
    {
        status = response.Data.Status.ToString(),
        isComplete = response.Data.Status == EZipExtractStatus.COMPLETED,
        isFailed = response.Data.Status == EZipExtractStatus.FAILED
    });
}

public record ExtractRequest(string ZipPath, string Destination);
```

### Generate Presigned URLs

**Manual (Console App):**

```csharp
var response = await sdk.GetPresignedURLAsync(
    EPresignedType.Download,
    "documents/report.pdf",
    new() { ExpireSeconds = 3600 });

string signature = response.Data.Signature;
int expiresIn = response.Data.ExpriresInSeconds;

Console.WriteLine($"Signature: {signature}");
Console.WriteLine($"Expires in: {expiresIn} seconds");
```

**Dependency Injection (ASP.NET Core):**

```csharp
[HttpGet("presigned-url")]
public async Task<IActionResult> GeneratePresignedUrl(
    [FromQuery] string objectKey,
    [FromQuery] string type = "download",
    [FromQuery] int expireSeconds = 3600)
{
    var presignedType = type.ToLower() == "upload" ? EPresignedType.Upload : EPresignedType.Download;

    var response = await _sdk.GetPresignedURLAsync(
        presignedType,
        objectKey,
        new() { ExpireSeconds = expireSeconds });

    return Ok(new
    {
        signature = response.Data.Signature,
        expiresInSeconds = response.Data.ExpriresInSeconds,
        activeFrom = response.Data.ActiveFrom
    });
}
```

### List Objects with Pagination

**Manual (Console App):**

```csharp
string? continuationToken = null;
int totalObjects = 0;

do
{
    var response = await sdk.ListAllObjectsAsync(
        MaxKeys: 100,
        ContinuationToken: continuationToken,
        Prefix: "documents/");

    foreach (var obj in response.Data)
    {
        Console.WriteLine($"{obj.ObjectKey} - {obj.Size} bytes");
        totalObjects++;
    }

    continuationToken = response.Data.FirstOrDefault()?.ContinuationToken;
}
while (!string.IsNullOrEmpty(continuationToken));

Console.WriteLine($"Total objects: {totalObjects}");
```

**Dependency Injection (ASP.NET Core):**

```csharp
[HttpGet("list")]
public async Task<IActionResult> ListObjects(
    [FromQuery] string? prefix = null, 
    [FromQuery] int maxKeys = 100,
    [FromQuery] string? continuationToken = null)
{
    var response = await _sdk.ListAllObjectsAsync(
        MaxKeys: maxKeys,
        ContinuationToken: continuationToken,
        Prefix: prefix);

    return Ok(new
    {
        objects = response.Data.Select(obj => new
        {
            key = obj.ObjectKey,
            size = obj.Size,
            lastModified = obj.LastModified
        }),
        continuationToken = response.Data.FirstOrDefault()?.ContinuationToken
    });
}
```

### Rename Objects

**Manual (Console App):**

```csharp
await sdk.RenameObjectAsync(
    "documents/old-name.pdf",
    "documents/new-name.pdf");

Console.WriteLine("File renamed successfully");
```

**Dependency Injection (ASP.NET Core):**

```csharp
[HttpPatch("rename")]
public async Task<IActionResult> RenameFile([FromBody] RenameRequest renameRequest)
{
    await _sdk.RenameObjectAsync(
        renameRequest.CurrentKey,
        renameRequest.NewKey);
    return Ok(new { message = "File renamed successfully" });
}

public record RenameRequest(string CurrentKey, string NewKey);
```

### Upload

**Manual (Console App):**

```csharp
using StratusSDK;

var options = new StratusOptions
{
    BucketName = "documents",
    ProjectID = "1234567890",
    Region = ERegion.US,
    // Environment defaults to Development; override if needed:
    // Environment = EStratusEnvironment.Production,
    ClientID = "your-client-id",
    ClientSecret = "your-client-secret",
    RefreshToken = "your-refresh-token",
    RedirectUrl = "your-redirect-url"
};

var sdk = StratusSDKFactory.Create(options);

// Upload a file from disk
await sdk.UploadAsync(
    "documents/report.pdf",
    UploadContent.FromFile("C:/reports/quarterly.pdf"),
    EContentType.ApplicationPdf);

// Upload a string
await sdk.UploadAsync(
    "config/settings.json",
    UploadContent.FromString("{\"key\": \"value\"}"));

// Upload raw bytes
byte[] imageBytes = await File.ReadAllBytesAsync("photo.png");
await sdk.UploadAsync(
    "images/photo.png",
    UploadContent.FromBytes(imageBytes),
    EContentType.ImagePng);

// Upload a stream
using var stream = File.OpenRead("data.bin");
await sdk.UploadAsync(
    "data/file.bin",
    UploadContent.FromStream(stream),
    EContentType.ApplicationOctetStream);
```

**Dependency Injection (ASP.NET Core):**

```csharp
using StratusSDK;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IStratusSDK _sdk;

    public DocumentsController(IStratusSDK sdk)
    {
        _sdk = sdk;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadDocument(IFormFile file)
    {
        using var stream = file.OpenReadStream();

        await _sdk.UploadAsync(
            $"documents/{file.FileName}",
            UploadContent.FromStream(stream));

        return Ok(new { message = "Document uploaded successfully" });
    }
}
```

## Data Models Reference

This section provides detailed information about all data models, request/response classes, enums, and configuration options used in the SDK.

### Configuration

#### StratusOptions

Configuration class for initializing the Stratus SDK.

| Property | Type | Required | Description | Example |
|----------|------|----------|-------------|---------|
| `BucketName` | `string` | Yes | Name of the Stratus bucket | `"my-storage-bucket"` |
| `ProjectID` | `string` | Yes | Catalyst project identifier | `"1234567890"` |
| `Region` | `ERegion` | Yes | Data center region | `ERegion.US` |
| `ClientID` | `string` | Yes (required) | OAuth client ID | `"1000.XXXXX"` |
| `ClientSecret` | `string` | Yes (required) | OAuth client secret | `"xxxxxxxxxxxxx"` |
| `RefreshToken` | `string` | Yes (required) | OAuth refresh token | `"1000.xxxxx.xxxxx"` |
| `OrgId` | `string?` | No | Organization ID (optional) | `"60012345678"` |
| `Environment` | `EStratusEnvironment?` | No | Stratus environment. Defaults to `Development`; can be overridden to `Production` | `EStratusEnvironment.Production` |
| `RedirectUrl` | `string` | Yes (required) | OAuth redirect URL | `"https://your-app.com/callback"` |
| `BaseUrl` | `string` | Read-only | Auto-generated API URL from Region | `"https://api.catalyst.zoho.com"` |

**Example:**
```csharp
var options = new StratusOptions
{
    BucketName = "documents",
    ProjectID = "1234567890",
    Region = ERegion.US,
    // Environment defaults to Development; override if needed:
    // Environment = EStratusEnvironment.Production,
    ClientID = "1000.ABCDEF",
    ClientSecret = "secret123",
    RefreshToken = "1000.refresh.token",
    RedirectUrl = "https://your-app.com/callback"
};
```

### Request Models

#### DeleteObjectRequestData

Object identifier for deletion (used with `DeleteObjectsAsync`).

| Property | Type | Required | Description | Example |
|----------|------|----------|-------------|---------|
| `Key` | `string` | Yes | Object key to delete | `"temp/file.txt"` |
| `VersionId` | `string?` | No | Specific version to delete | `"01hh9hkfdf07y8pnpbwtkt8cf7"` |

#### DownloadHeaderOptions

Configuration options for download operations.

| Property | Type | Default | Description | Example |
|----------|------|---------|-------------|---------|
| `Range` | `int?` | `null` | Byte range to download | `1024` |
| `RetrieveMeta` | `bool?` | `null` | Include metadata in response | `true` |

#### DownloadObjectRequest

Request model for downloading objects from storage.

| Property | Type | Required | Description | Example |
|----------|------|----------|-------------|---------|
| `ObjectKey` | `string` | Yes | Path/key of the object to download | `"documents/report.pdf"` |
| `VersionId` | `string?` | No | Specific version to download | `"01hh9hkfdf07y8pnpbwtkt8cf7"` |
| `HeaderOptions` | `DownloadHeaderOptions?` | No | Download configuration options | See DownloadHeaderOptions above |

#### PresignedUrlOptions

Optional settings for presigned URL generation.

| Property | Type | Default | Description | Example |
|----------|------|---------|-------------|---------|
| `ExpireSeconds` | `int?` | `3600` | URL validity in seconds | `7200` (2 hours) |
| `ActiveFrom` | `TimeOnly?` | `null` | URL active from time | `new TimeOnly(14, 30)` |
| `VersionId` | `string?` | `null` | Specific version | `"version123"` |

#### PutObjectMetadataRequestBody

Request body for updating object metadata.

| Property | Type | Required | Description | Example |
|----------|------|----------|-------------|---------|
| `Metadata` | `Dictionary<string, string>` | Yes | Custom metadata key-value pairs | `{ "Author": "Shahil" }` |

#### UploadContent

Static factory class for creating upload content (`IStratusHttpContent`) to pass to `UploadAsync`. Each factory method wraps your data source so the SDK can send it as an HTTP request body.

| Factory Method | Input Type | Default Content Type | Description |
|----------------|-----------|----------------------|-------------|
| `UploadContent.FromFile(path, contentType?)` | `string` (file path) | `ApplicationOctetStream` | Reads a file from disk |
| `UploadContent.FromStream(stream, contentType?)` | `Stream` | `ApplicationOctetStream` | Uploads from an open stream (caller manages lifetime) |
| `UploadContent.FromBytes(bytes, contentType?)` | `byte[]` | `ApplicationOctetStream` | Uploads raw bytes |
| `UploadContent.FromString(content, contentType?)` | `string` | `TextPlain` | Uploads UTF-8 encoded string content |

**Examples:**
```csharp
// From a file on disk
var fileContent = UploadContent.FromFile("C:/reports/report.pdf");

// From a stream
using var stream = File.OpenRead("data.bin");
var streamContent = UploadContent.FromStream(stream);

// From raw bytes
byte[] bytes = await File.ReadAllBytesAsync("image.png");
var bytesContent = UploadContent.FromBytes(bytes);

// From a string
var stringContent = UploadContent.FromString("{\"key\": \"value\"}");
```

#### UploadHeaderOptions

Configuration options for upload operations.

| Property | Type | Default | Description | Example |
|----------|------|---------|-------------|---------|
| `ContentType` | `EContentType` | `TextPlain` | MIME type of the object | `EContentType.ApplicationPdf` |
| `ContentLength` | `int?` | Auto-calculate | Size in bytes | `1024` |
| `Compress` | `bool?` | `true` | Enable compression | `true` |
| `Overwrite` | `bool?` | `null` | Overwrite existing objects (non-versioned buckets only) | `true` |
| `ExpiresAfter` | `float` | `0` | Auto-delete after seconds (min: 60) | `86400` (24 hours) |
| `Metadata` | `Dictionary<string, string>?` | `null` | Custom metadata (max: 2047 chars total) | `{ "category": "reports" }` |

#### UploadObjectRequestOptions

Optional settings for upload operations.

| Property | Type | Required | Description | Example |
|----------|------|----------|-------------|---------|
| `HeaderOptions` | `UploadHeaderOptions?` | No | Upload configuration options | See UploadHeaderOptions above |
| `VersionId` | `string?` | No | Version ID for versioned buckets | `"01hh9hkfdf07y8pnpbwtkt8cf7"` |

### Response Models

#### Bucket

Represents a Stratus bucket with metadata.

| Property | Type | Description |
|----------|------|-------------|
| `Name` | `string` | Bucket name |
| `ProjectDetails` | `ProjectDetails` | Associated project information |
| `CreatedBy` | `ModifiedData` | Creator information |
| `CreatedTime` | `DateTime` | Creation timestamp |
| `ModifiedBy` | `ModifiedData` | Last modifier information |
| `ModifiedTime` | `DateTime` | Last modification timestamp |
| `Meta` | `BucketMeta` | Bucket metadata and settings |
| `Url` | `string` | Bucket URL |

#### BucketObject

Represents an object in storage.

| Property | Type | Description |
|----------|------|-------------|
| `KeyType` | `EStratusKeyType` | Object type (File/Folder) |
| `Key` | `string` | Object key/path |
| `VersionId` | `string?` | Version identifier |
| `Size` | `long` | Size in bytes |
| `ContentType` | `string?` | MIME content type |
| `ETag` | `string?` | Entity tag for caching |
| `LastModified` | `DateTime` | Last modification time |

#### CreateBucketSignatureData

Bucket signature details.

| Property | Type | Description |
|----------|------|-------------|
| `Signature` | `string` | The STS policy signature string for secure bucket access |
| `ExpiryTime` | `long` | Signature expiry timestamp (Unix epoch in milliseconds) |

#### CreateBucketSignatureResponse

Response from bucket signature creation.

| Property | Type | Description |
|----------|------|-------------|
| `Status` | `string` | Response status (e.g., `"success"`) |
| `Success` | `bool` | Whether the operation succeeded |
| `Data` | `CreateBucketSignatureData` | Signature data |

#### DownloadObjectResponse

Response from download operation.

| Property | Type | Description |
|----------|------|-------------|
| `Success` | `bool` | Whether the download succeeded |
| `Message` | `string` | Status message |
| `Data` | `byte[]?` | Downloaded file content |

#### GetAllObjectResponseData

Individual object data in list response.

| Property | Type | Description |
|----------|------|-------------|
| `ObjectKey` | `string` | Object key/path |
| `Size` | `long` | Size in bytes |
| `KeyType` | `string` | Type identifier |
| `VersionId` | `string?` | Version identifier |
| `ETag` | `string?` | Entity tag |
| `LastModified` | `DateTime` | Last modification time |
| `ContinuationToken` | `string?` | Token for next page |

#### GetAllObjectsResponse

Response from list objects operation.

| Property | Type | Description |
|----------|------|-------------|
| `Data` | `List<GetAllObjectResponseData>` | List of objects |

#### GetStatusOfZipExtractData

ZIP extraction status details.

| Property | Type | Description |
|----------|------|-------------|
| `Status` | `EZipExtractStatus` | Extraction status (PENDING/COMPLETED/FAILED) |
| `TaskId` | `string` | Extraction task identifier |

#### GetStatusOfZipExtractResponse

Response from ZIP extraction status check.

| Property | Type | Description |
|----------|------|-------------|
| `Data` | `GetStatusOfZipExtractData` | Extraction status data |

#### PresignedUrlData

Presigned URL details.

| Property | Type | Description |
|----------|------|-------------|
| `Signature` | `string` | URL signature for authentication |
| `ExpriresInSeconds` | `int` | Validity duration in seconds |
| `ActiveFrom` | `int` | Activation timestamp |

#### PresignedURLResponse

Response from presigned URL generation.

| Property | Type | Description |
|----------|------|-------------|
| `Data` | `PresignedUrlData` | Presigned URL data |

### Enumerations

#### ECachingStatus

Bucket caching status.

| Value | Description |
|-------|-------------|
| `Enabled` | Caching is active |
| `Disabled` | Caching is inactive |
| `InProgress` | Caching is being configured |

#### EContentType

Supported MIME content types for uploads.

| Value | MIME Type | Use Case |
|-------|-----------|----------|
| `ApplicationJson` | `application/json` | JSON files |
| `TextPlain` | `text/plain` | Text files |
| `ApplicationOctetStream` | `application/octet-stream` | Binary files |
| `ImagePng` | `image/png` | PNG images |
| `ImageJpeg` | `image/jpeg` | JPEG images |
| `ImageGif` | `image/gif` | GIF images |
| `VideoMp4` | `video/mp4` | MP4 videos |
| `AudioMpeg` | `audio/mpeg` | MP3 audio |
| `ApplicationPdf` | `application/pdf` | PDF documents |
| `ApplicationZip` | `application/zip` | ZIP archives |

**Example:**
```csharp
var options = new UploadHeaderOptions
{
    ContentType = EContentType.ImageJpeg
};
```

#### EPresignedType

Type of presigned URL to generate.

| Value | Description | Use Case |
|-------|-------------|----------|
| `Upload` | Upload URL | Allow temporary upload access |
| `Download` | Download URL | Share files temporarily |

**Example:**
```csharp
var response = await sdk.GetPresignedURLAsync(
    EPresignedType.Download,
    "shared/document.pdf",
    new() { ExpireSeconds = 3600 });
```

#### ERegion

Available data center regions.

| Value | Description | Location |
|-------|-------------|----------|
| `US` | United States | North America |
| `EU` | European Union | Europe |
| `IN` | India | Asia Pacific |
| `AU` | Australia | Asia Pacific |
| `JP` | Japan | Asia Pacific |
| `CA` | Canada | North America |

**Example:**
```csharp
var options = new StratusOptions
{
    Region = ERegion.EU // Use European data center
};
```

#### EStratusKeyType

Type of storage object.

| Value | Description |
|-------|-------------|
| `File` | Regular file object |
| `Folder` | Directory/folder object |

#### EZipExtractStatus

Status of ZIP extraction operation.

| Value | Description |
|-------|-------------|
| `PENDING` | Extraction queued or in progress |
| `COMPLETED` | Extraction finished successfully |
| `FAILED` | Extraction failed |

**Example:**
```csharp
var status = await sdk.GetExtractionStatusAsync(taskId);

switch (status.Data.Status)
{
    case EZipExtractStatus.COMPLETED:
        Console.WriteLine("Extraction complete!");
        break;
    case EZipExtractStatus.PENDING:
        Console.WriteLine("Still extracting...");
        break;
    case EZipExtractStatus.FAILED:
        Console.WriteLine("Extraction failed!");
        break;
}
```

### Interfaces

#### IStratusSDK

Main SDK interface defining all operations.

**Methods:**

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CopyObjectAsync()` | `Task<CopyObjectResponse>` | Copy objects |
| `CreateBucketSignatureAsync()` | `Task<CreateBucketSignatureResponse>` | Create bucket signature |
| `DeleteObjectAsync()` | `Task<DeleteObjectResponse>` | Delete a single object |
| `DeleteObjectsAsync()` | `Task<DeleteObjectResponse>` | Delete multiple objects |
| `DeletePathAsync()` | `Task<DeletePathResponse>` | Delete path recursively |
| `DownloadObjectAsync()` | `Task<DownloadObjectResponse>` | Download objects |
| `ExistsBucketAsync()` | `Task<ExistsBucketResponse>` | Check bucket existence |
| `ExistsObjectAsync()` | `Task<ExistsObjectResponse>` | Check object existence |
| `ExtractZipObjectAsync()` | `Task<ExtractZipObjectResponse>` | Extract ZIP file |
| `GetBucketAsync()` | `Task<GetBucketResponse>` | Get bucket information |
| `GetExtractionStatusAsync()` | `Task<GetStatusOfZipExtractResponse>` | Check extraction status |
| `GetObjectAsync()` | `Task<GetObjectResponse>` | Get object metadata |
| `GetObjectVersionsAsync()` | `Task<GetAllObjectVersionsResponse>` | List object versions |
| `GetPresignedURLAsync()` | `Task<PresignedURLResponse>` | Generate presigned URL |
| `ListAllBucketsAsync()` | `Task<ListBucketResponse>` | List all buckets |
| `ListAllObjectsAsync()` | `Task<ListAllObjectsResponse>` | List objects |
| `PutObjectMetadataAsync()` | `Task<PutObjectMetadataResponse>` | Update object metadata |
| `RenameObjectAsync()` | `Task<RenameObjectResponse>` | Rename objects |
| `UploadAsync()` | `Task<UploadObjectResponse>` | Upload content (file, stream, bytes, or string) via `UploadContent` |

**Usage:**

The interface is implemented by the `StratusSDK` class and can be injected via DI:

```csharp
public class MyService
{
    private readonly IStratusSDK _sdk;

    public MyService(IStratusSDK sdk)
    {
        _sdk = sdk;
    }

    public async Task ProcessFile()
    {
        await _sdk.UploadAsync(
            "file.txt",
            UploadContent.FromString("Hello, Stratus!"));
    }
}
```

## API Reference

### Object Operations

---

#### `CopyObjectAsync`

Copies an object from one location to another within the bucket.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKey` | `string` | Yes | Source object key to copy from |
| `destination` | `string` | Yes | Destination key where the object will be copied to |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<CopyObjectResponse>`

```csharp
await sdk.CopyObjectAsync(
    "documents/report.pdf",
    "archive/2024/report.pdf");
```

---

#### `DeleteObjectAsync`

Deletes a single object from the bucket.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKey` | `string` | Yes | The object key to delete |
| `versionId` | `string?` | No | Specific version to delete |
| `ttlInSeconds` | `int?` | No | Delay deletion by seconds (min: 60) |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<DeleteObjectResponse>`

```csharp
// Delete a single object
await sdk.DeleteObjectAsync("temp/file1.txt");

// Delete a specific version with delayed deletion
await sdk.DeleteObjectAsync(
    "temp/file1.txt",
    versionId: "version123",
    ttlInSeconds: 300);
```

---

#### `DeleteObjectsAsync`

Deletes multiple objects from the bucket. Supports two overloads.

**Overload 1 — with `DeleteObjectRequestData`:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKeys` | `List<DeleteObjectRequestData>` | Yes | List of objects to delete (supports version IDs) |
| `ttlInSeconds` | `int?` | No | Delay deletion by seconds (min: 60) |
| `ct` | `CancellationToken` | No | Cancellation token |

**Overload 2 — with string keys:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKeys` | `List<string>` | Yes | List of object keys to delete |
| `ttlInSeconds` | `int?` | No | Delay deletion by seconds (min: 60) |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<DeleteObjectResponse>`

```csharp
// Delete multiple objects by key
await sdk.DeleteObjectsAsync(
    new List<string> { "temp/file1.txt", "temp/file2.txt" });

// Delete multiple objects with version control
await sdk.DeleteObjectsAsync(
    new List<DeleteObjectRequestData>
    {
        new() { Key = "temp/file1.txt" },
        new() { Key = "temp/file2.txt", VersionId = "version123" }
    });
```

---

#### `DeletePathAsync`

Deletes all objects matching a specified prefix (path) in the bucket.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `prefix` | `string` | Yes | The prefix path to delete all objects under |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<DeletePathResponse>`

```csharp
await sdk.DeletePathAsync("temp/uploads/");
```

---

#### `DownloadObjectAsync`

Downloads an object from the bucket.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `request` | `DownloadObjectRequest` | Yes | Download request with object key, optional version, and header options |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<DownloadObjectResponse>`

```csharp
var response = await sdk.DownloadObjectAsync(new DownloadObjectRequest
{
    ObjectKey = "documents/report.pdf",
    VersionId = "01hh9hkfdf07y8pnpbwtkt8cf7" // optional
});

await File.WriteAllBytesAsync("report.pdf", response.Data!);
```

---

#### `ExistsObjectAsync`

Checks if a specific object exists in the bucket.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKey` | `string` | Yes | Object key to check |
| `versionId` | `string?` | No | Specific version to check |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<ExistsObjectResponse>`

```csharp
var result = await sdk.ExistsObjectAsync("documents/report.pdf");

// Check a specific version
var versionResult = await sdk.ExistsObjectAsync(
    "documents/report.pdf",
    versionId: "01hh9hkfdf07y8pnpbwtkt8cf7");
```

---

#### `RenameObjectAsync`

Renames an object in the bucket.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `currentKey` | `string` | Yes | The current object key |
| `renameTo` | `string` | Yes | The new object key |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<RenameObjectResponse>`

```csharp
await sdk.RenameObjectAsync(
    "documents/draft.pdf",
    "documents/final-report.pdf");
```

---

#### `UploadAsync`

Uploads content to storage. Use the `UploadContent` factory to create the content from a file path, stream, byte array, or string.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKey` | `string` | Yes | Destination object key |
| `content` | `IStratusHttpContent` | Yes | Upload content created via `UploadContent.FromFile()`, `.FromStream()`, `.FromBytes()`, or `.FromString()` |
| `contentType` | `EContentType` | No | MIME content type (default: `TextPlain`) |
| `options` | `UploadObjectRequestOptions?` | No | Optional upload settings including header options and version ID |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<UploadObjectResponse>`

**Upload a file from disk:**
```csharp
await sdk.UploadAsync(
    "reports/quarterly.pdf",
    UploadContent.FromFile("C:/reports/quarterly.pdf"),
    EContentType.ApplicationPdf);
```

**Upload a string:**
```csharp
var json = JsonSerializer.Serialize(new { name = "test" });

await sdk.UploadAsync(
    "config/settings.json",
    UploadContent.FromString(json));
```

**Upload raw bytes:**
```csharp
byte[] imageBytes = await File.ReadAllBytesAsync("photo.png");

await sdk.UploadAsync(
    "images/photo.png",
    UploadContent.FromBytes(imageBytes),
    EContentType.ImagePng);
```

**Upload a stream:**
```csharp
using var stream = File.OpenRead("data.bin");

await sdk.UploadAsync(
    "data/file.bin",
    UploadContent.FromStream(stream),
    EContentType.ApplicationOctetStream);
```

---

### Metadata & Information

---

#### `GetObjectAsync`

Retrieves metadata and information about a specific object.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKey` | `string` | Yes | Object key to retrieve metadata for |
| `versionId` | `string?` | No | Specific version to get metadata for (pass `null` for latest) |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<GetObjectResponse>`

```csharp
var metadata = await sdk.GetObjectAsync("documents/report.pdf");
```

---

#### `GetObjectVersionsAsync`

Retrieves all versions of a specific object.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKey` | `string` | Yes | Object key to list versions for |
| `maxVersion` | `int?` | No | Maximum number of versions to return |
| `continuationToken` | `string?` | No | Pagination token from a previous response |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<GetAllObjectVersionsResponse>`

```csharp
var versions = await sdk.GetObjectVersionsAsync(
    "documents/report.pdf",
    maxVersion: 10);
```

---

#### `ListAllObjectsAsync`

Lists all objects in the bucket with optional filtering and pagination.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `MaxKeys` | `int?` | No | Maximum number of results per page |
| `ContinuationToken` | `string?` | No | Pagination token from a previous response |
| `Prefix` | `string?` | No | Filter objects by key path prefix |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<ListAllObjectsResponse>`

```csharp
// List all objects
var result = await sdk.ListAllObjectsAsync();

// List with filtering and pagination
var filtered = await sdk.ListAllObjectsAsync(
    MaxKeys: 100,
    Prefix: "documents/");
```

---

#### `PutObjectMetadataAsync`

Updates custom metadata on an existing object.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKey` | `string` | Yes | Object key to update metadata for |
| `content` | `PutObjectMetadataRequestBody` | Yes | The metadata key-value pairs to set |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<PutObjectMetadataResponse>`

```csharp
await sdk.PutObjectMetadataAsync(
    "documents/report.pdf",
    new()
    {
        Metadata = new()
        {
            { "Author", "Shahil" },
            { "Description", "Quarterly report" }
        }
    });
```

---

### Bucket Operations

---

#### `CreateBucketSignatureAsync`

Creates a signature for the bucket to enable secure access.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<CreateBucketSignatureResponse>`

```csharp
var response = await sdk.CreateBucketSignatureAsync();

string signature = response.Data.Signature;
long expiryTime = response.Data.ExpiryTime;
```

---

#### `ExistsBucketAsync`

Checks if the configured bucket exists.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<ExistsBucketResponse>`

```csharp
var result = await sdk.ExistsBucketAsync();
```

---

#### `GetBucketAsync`

Retrieves bucket information and metadata.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<GetBucketResponse>`

```csharp
var bucket = await sdk.GetBucketAsync();
```

---

#### `ListAllBucketsAsync`

Lists all buckets available in the project.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<ListBucketResponse>`

```csharp
var buckets = await sdk.ListAllBucketsAsync();
```

---

### Advanced Operations

---

#### `ExtractZipObjectAsync`

Extracts a zipped object in the bucket to a specified destination.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `objectKey` | `string` | Yes | Object key of the ZIP file to extract |
| `destination` | `string` | Yes | Destination path for the extracted contents |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<ExtractZipObjectResponse>`

```csharp
var response = await sdk.ExtractZipObjectAsync(
    "archives/data.zip",
    "extracted/data/");

string taskId = response.Data.TaskId;
```

---

#### `GetExtractionStatusAsync`

Gets the status of a zip extraction operation.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `taskId` | `string` | Yes | The task ID returned from `ExtractZipObjectAsync` |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<GetStatusOfZipExtractResponse>`

```csharp
var status = await sdk.GetExtractionStatusAsync(taskId);

if (status.Data.Status == EZipExtractStatus.COMPLETED)
    Console.WriteLine("Extraction complete!");
```

---

#### `GetPresignedURLAsync`

Generates a presigned URL for uploading or downloading an object without authentication.

**Parameters:**

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| `Type` | `EPresignedType` | Yes | The type of presigned URL (Upload or Download) |
| `objectKey` | `string` | Yes | Object key to generate the URL for |
| `options` | `PresignedUrlOptions?` | No | Optional settings including expiration, activation time, and version ID |
| `ct` | `CancellationToken` | No | Cancellation token |

**Returns:** `Task<PresignedURLResponse>`

```csharp
var response = await sdk.GetPresignedURLAsync(
    EPresignedType.Download,
    "documents/report.pdf",
    new() { ExpireSeconds = 3600 });

string signature = response.Data.Signature;
```

## Error Handling

The SDK uses two exception types:

### StratusException

Thrown when API operations fail:

```csharp
try
{
    await sdk.DownloadObjectAsync(request);
}
catch (StratusException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
    Console.WriteLine($"Status Code: {ex.StatusCode}");
    Console.WriteLine($"Error Code: {ex.ErrorCode}");

    // Handle specific error codes
    if (ex.StatusCode == HttpStatusCode.NotFound)
    {
        Console.WriteLine("Object not found");
    }
}
```

### StratusAuthenticationException

Thrown when OAuth authentication fails:

```csharp
try
{
    var sdk = StratusSDKFactory.Create(options);
}
catch (StratusAuthenticationException ex)
{
    Console.WriteLine($"Authentication failed: {ex.Message}");
    // Check your ClientID, ClientSecret, and RefreshToken
}
```

## Operation Stability

Operations are categorized based on their testing status:

### Stable Operations

These operations have been thoroughly tested and are ready for production use:

| Operation | Description |
|-----------|-------------|
| `CopyObjectAsync()` | Copy objects |
| `CreateBucketSignatureAsync()` | Create bucket signature |
| `DeleteObjectAsync()` | Delete a single object |
| `DeleteObjectsAsync()` | Delete multiple objects |
| `DeletePathAsync()` | Delete path recursively |
| `DownloadObjectAsync()` | Download objects |
| `ExistsBucketAsync()` | Check bucket existence |
| `ExistsObjectAsync()` | Check object existence |
| `ExtractZipObjectAsync()` | Extract ZIP file in cloud |
| `GetBucketAsync()` | Get bucket information |
| `GetExtractionStatusAsync()` | Check extraction status |
| `GetPresignedURLAsync()` | Generate presigned URLs (upload and download) |
| `ListAllBucketsAsync()` | List all buckets |
| `ListAllObjectsAsync()` | List all objects |
| `PutObjectMetadataAsync()` | Update object metadata |
| `RenameObjectAsync()` | Rename objects |
| `UploadAsync()` | Upload content (file, stream, bytes, or string) |

### Experimental Operations

These operations are functional but have limited testing. Use with caution in production:

| Operation | Description | Notes |
|-----------|-------------|-------|
| `GetObjectVersionsAsync()` | List object versions | Not fully tested yet |

## Known Limitations & Improvements

- **Version-based operations** (`GetObjectVersionsAsync`, downloading/checking a specific `versionId`) have not been fully tested yet.
- **`GetObjectAsync`** has not been explicitly stability-classified in the test suite.

## Best Practices

### ✅ Do

- **Reuse SDK instances** - Create once, use multiple times
- **Use async/await** - All operations are asynchronous
- **Handle exceptions** - Always wrap calls in try-catch blocks
- **Set metadata** - Use custom metadata for better organization
- **Use pagination** - For large listings, use continuation tokens
- **Validate inputs** - Check object keys and paths before operations

### ❌ Don't

- **Don't hardcode credentials** - Use environment variables or secure storage
- **Don't ignore errors** - Always handle exceptions appropriately
- **Don't upload large files synchronously** - Use proper async patterns
- **Don't forget versioning** - Specify version IDs when needed
- **Don't skip metadata** - Metadata helps with organization and search

## Advanced Configuration

### Upload Options

Configure uploads with `UploadHeaderOptions`:

```csharp
var options = new UploadHeaderOptions
{
    ContentType = EContentType.ApplicationJson,
    ContentLength = 1024,
    Overwrite = true,
    ExpiresAfter = 86400, // 24 hours
    Compress = true,
    Metadata = new Dictionary<string, string>
    {
        { "category", "logs" }
    }
};
```

### Download Options

Configure downloads with `DownloadHeaderOptions`:

```csharp
var options = new DownloadHeaderOptions
{
    Range = "bytes=0-1023", // Download first 1KB
    RetrieveMeta = true
};
```

## Performance Tips

1. **Batch Operations** - Use batch delete for multiple objects
2. **Connection Pooling** - Reuse HttpClient (handled automatically)
3. **Parallel Uploads** - Use `Task.WhenAll()` for multiple uploads
4. **Pagination** - Use appropriate page sizes (100-1000 items)
5. **Compression** - Enable compression for text files

## Troubleshooting

### Common Issues

**Issue: Authentication fails**
- Verify ClientID, ClientSecret, and RefreshToken
- Ensure tokens haven't expired
- Check region setting matches your Catalyst account

**Issue: Object not found**
- Check object key spelling and case sensitivity
- Verify bucket name is correct
- Ensure object exists using `ExistsObjectAsync()`

**Issue: Upload fails**
- Check file size limits
- Verify bucket permissions
- Ensure network connectivity

**Issue: Timeout errors**
- Increase timeout for large files
- Check network stability
- Verify service availability

## Requirements

- .NET 10.0 or higher
- Valid Zoho Catalyst account
- Active Catalyst project with Stratus enabled

## Support

- **GitHub Issues**: [Report bugs or request features](https://github.com/shahilsaha05uk/bb-api/issues)
- **Repository**: [View source code](https://github.com/shahilsaha05uk/bb-api)
- **Documentation**: See `docs/html/index.html` for complete API reference

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Changelog

### Version 1.3.0
- **Breaking:** Replaced `UploadFileAsync()`, `UploadStreamAsync()`, `UploadStringAsync()`, `UploadBytesAsync()`, and `UploadFileAsStreamAsync()` with a single `UploadAsync()` method
- Added `UploadContent` static factory class with `FromFile()`, `FromStream()`, `FromBytes()`, and `FromString()` methods to create upload content
- `UploadAsync()` accepts `IStratusHttpContent` (created via `UploadContent`) and an optional `EContentType` parameter
- Removed `Samples/StratusController.cs` from the SDK package

### Version 1.2.0
- All public methods now use the `Async` suffix consistently (`UploadFileAsync`, `GetPresignedURLAsync`, `GetExtractionStatusAsync`, `GetObjectVersionsAsync`)
- `DeleteObjectAsync` now accepts inline parameters (`objectKey`, `versionId?`, `ttlInSeconds?`) instead of a request object
- Added `DeleteObjectsAsync` overloads for batch deletion (with `List<DeleteObjectRequestData>` or `List<string>`)
- `GetExtractionStatusAsync` now accepts `taskId` instead of `objectKey`
- `ListAllObjectsAsync` parameters are now all optional with defaults
- Added `CreateBucketSignatureResponse` and `CreateBucketSignatureData` response models to documentation
- Promoted upload, delete, extract, and bucket signature operations from Experimental to Stable

### Version 1.1.0
- Simplified public API — most methods now accept inline `string` parameters instead of request objects
- Renamed `CopyObject()` to `CopyObjectAsync()` for naming consistency
- `ExistsObjectAsync()` now returns `ExistsObjectResponse` instead of `bool`
- `GetPresignedURL()` now accepts `(EPresignedType, string, PresignedUrlOptions?)` instead of a `PresignedUrlRequest`
- Upload methods now take `objectKey` as the first parameter with optional `UploadObjectRequestOptions`
- Added `PutObjectMetadataAsync()` for updating object metadata
- Replaced `NonContentUploadObjectRequest` with `UploadObjectRequestOptions`
- Replaced `PresignedUrlRequest` with `PresignedUrlOptions` (only optional fields)
- Added operation stability classification (Stable / Experimental)

### Version 1.0.0
- Initial release
- Core object operations (upload, download, delete, copy, rename)
- Bucket management
- Presigned URL generation
- ZIP extraction support
- Comprehensive error handling
- Full API documentation

---

Made with ❤️ for .NET developers
