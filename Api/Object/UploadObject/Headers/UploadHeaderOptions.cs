
using StratusSDK.Core.Constants.Keys;

namespace StratusSDK
{
    /// <summary>
    /// Configures HTTP headers and options for object upload operations.
    /// </summary>
    /// <remarks>
    /// Use this class to customize upload behavior including content type, compression,
    /// overwrite settings, expiration, and custom metadata.
    /// </remarks>
    /// <seealso cref="UploadObjectRequest"/>
    /// <seealso cref="UploadObjectRequest.HeaderOptions"/>
    public sealed class UploadHeaderOptions : HeaderProviderBase
    {
        /// <summary>
        /// Gets or initializes the MIME content type of the object being uploaded.
        /// </summary>
        /// <value>
        /// An <see cref="EContentType"/> enum value specifying the content type, or null to auto-detect.
        /// </value>
        /// <remarks>
        /// Common values include <see cref="EContentType.ApplicationJson"/>, 
        /// <see cref="EContentType.ImageJpeg"/>, <see cref="EContentType.ApplicationPdf"/>, etc.
        /// If not specified, the content type will be auto-detected from the file extension.
        /// </remarks>
        /// <seealso cref="EContentType"/>
        public EContentType ContentType { get; init; } = EContentType.TextPlain;

        /// <summary>
        /// Gets or initializes the raw length of the object being uploaded in bytes.
        /// </summary>
        /// <value>
        /// The content length in bytes, or null to automatically calculate from the content.
        /// </value>
        /// <remarks>
        /// Specifying the content length can improve upload performance by avoiding buffering.
        /// If not provided, it will be calculated automatically.
        /// </remarks>
        public int? ContentLength { get; init; }

        /// <summary>
        /// Gets or initializes whether to enable compression for the object being uploaded.
        /// </summary>
        /// <value>
        /// <c>true</c> to compress the object before uploading; <c>false</c> to upload without compression;
        /// <c>null</c> to use default (compression enabled).
        /// </value>
        /// <remarks>
        /// When enabled, the object will be compressed before uploading and automatically
        /// decompressed when downloaded. Default is <c>true</c>.
        /// </remarks>
        public bool? Compress { get; init; } = true;

        // Use this header to specify the browser caching policies.
        // TODO: This needs to be figured out
        // public string? CacheControl { get; init; }

        /// <summary>
        /// Gets or initializes whether to overwrite an existing object with the same key.
        /// </summary>
        /// <value>
        /// <c>true</c> to overwrite existing objects; <c>false</c> to fail if object exists;
        /// <c>null</c> to use default behavior.
        /// </value>
        /// <remarks>
        /// This is supported only for non-versioned buckets. For versioned buckets,
        /// a new version is automatically created instead of overwriting.
        /// </remarks>
        public bool? Overwrite { get; init; }

        /// <summary>
        /// Gets or initializes the time in seconds after which the uploaded object will automatically expire and be deleted.
        /// </summary>
        /// <value>
        /// The expiration time in seconds. Must be greater than 60 seconds if specified.
        /// </value>
        /// <remarks>
        /// Use this for temporary objects that should be automatically cleaned up.
        /// The object will be permanently deleted after the specified time period.
        /// Minimum value: 60 seconds.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Object expires after 1 hour (3600 seconds)
        /// var options = new UploadHeaderOptions { ExpiresAfter = 3600 };
        /// 
        /// // Object expires after 24 hours
        /// var options = new UploadHeaderOptions { ExpiresAfter = 86400 };
        /// </code>
        /// </example>
        public float ExpiresAfter { get; init; }

        /// <summary>
        /// Gets or initializes custom metadata for the object as key-value pairs.
        /// </summary>
        /// <value>
        /// A <see cref="Dictionary{TKey, TValue}"/> of metadata keys and values,
        /// or null for no custom metadata.
        /// </value>
        /// <remarks>
        /// <para>
        /// Use metadata to store custom information about the object such as tags,
        /// categories, original filename, or any application-specific data.
        /// </para>
        /// <para>
        /// Maximum total length: 2047 characters (including keys and values).
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var options = new UploadHeaderOptions
        /// {
        ///     Metadata = new Dictionary&lt;string, string&gt;
        ///     {
        ///         { "category", "documents" },
        ///         { "original-name", "report.pdf" },
        ///         { "uploaded-by", "user@example.com" }
        ///     }
        /// };
        /// </code>
        /// </example>
        public Dictionary<string, string>? Metadata { get; init; }

        public override Dictionary<string, string?> ToHeaders()
        {
            var headers = new Dictionary<string, string?>();

            AddIf(headers, HeaderKeys.ContentType, "text/plain");
            AddIf(headers, HeaderKeys.ContentLength, ContentLength);
            AddIf(headers, HeaderKeys.Overwrite, Overwrite);
            AddIf(headers, HeaderKeys.ExpiresAfter, ExpiresAfter);

            if (Metadata?.Count > 0)
            {
                headers[HeaderKeys.UserMeta] =
                    string.Join(";", Metadata.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            }

            return headers;
        }
    }
}