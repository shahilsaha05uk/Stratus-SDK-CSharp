using StratusSDK.Core.Constants;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    /// <summary>
    /// Configuration options for initializing the Stratus SDK.
    /// Contains authentication credentials and project settings required to interact with Zoho Catalyst Stratus.
    /// </summary>
    /// <remarks>
    /// This class must be configured with valid Zoho Catalyst credentials including ClientID, ClientSecret,
    /// and RefreshToken. The BucketName and ProjectID specify the target storage bucket and project.
    /// </remarks>
    public sealed class StratusOptions
    {
        /// <summary>
        /// Gets the base API URL determined by the configured region.
        /// </summary>
        /// <value>The base URL string for API calls.</value>
        public string BaseUrl => ApiDomain.GetDomain(Region);

        /// <summary>
        /// Gets or sets the name of the Stratus bucket to use for operations.
        /// </summary>
        /// <value>The bucket name as a string.</value>
        public string BucketName { get; set; } = string.Empty;
        public string DevBucketName => $"{BucketName}-development";
        public string BucketUrl => $"https://{BucketName}.{BucketDomains.GetDomain(Region)}";
        public string DevBucketUrl => $"https://{DevBucketName}.{BucketDomains.GetDomain(Region)}";

        /// <summary>
        /// Gets or sets the Zoho OAuth client ID.
        /// </summary>
        /// <value>The client ID string. This property is required.</value>
        public required string ClientID { get; set; }

        /// <summary>
        /// Gets or sets the Zoho OAuth client secret.
        /// </summary>
        /// <value>The client secret string. This property is required.</value>
        public required string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the Stratus environment (optional).
        /// </summary>
        /// <value>The environment enum value or null.</value>
        public EStratusEnvironment? Environment { get; set; }

        /// <summary>
        /// Gets or sets the JSON serializer options used for API requests and responses.
        /// </summary>
        /// <value>
        /// A JsonSerializerOptions instance configured with web defaults and enum string conversion.
        /// </value>
        public JsonSerializerOptions JsonOptions { get; set; }
            = new(JsonSerializerDefaults.Web)
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                },
            };

        /// <summary>
        /// Gets or sets the organization ID (optional).
        /// </summary>
        /// <value>The organization ID or null.</value>
        public string? OrgId { get; set; }

        /// <summary>
        /// Gets or sets the Zoho Catalyst project ID.
        /// </summary>
        /// <value>The project ID as a string.</value>
        public required string ProjectID { get; init; }

        public required string RedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets the Zoho OAuth refresh token for authentication.
        /// </summary>
        /// <value>The refresh token string. This property is required.</value>
        public required string RefreshToken { get; init; }

        /// <summary>
        /// Gets or sets the region where the Stratus bucket is hosted.
        /// </summary>
        /// <value>The region enum value.</value>
        public required ERegion Region { get; init; }
    }
}
