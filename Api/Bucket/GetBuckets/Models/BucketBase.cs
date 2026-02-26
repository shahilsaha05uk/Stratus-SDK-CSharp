using StratusSDK.Core.Constants.Keys;
using System.Globalization;
using System.Text.Json.Serialization;

namespace StratusSDK
{
    public abstract class BucketBase
    {
        [JsonPropertyName(JsonKeys.BucketName)]
        public string Name { get; init; } = default!;

        [JsonPropertyName(JsonKeys.BucketUrl)]
        public string Url { get; init; } = default!;

        [JsonPropertyName(JsonKeys.ProjectDetails)]
        public ProjectDetails ProjectDetails { get; init; } = default!;

        [JsonPropertyName(JsonKeys.CreatedBy)]
        public UserInfo CreatedBy { get; init; } = default!;

        [JsonPropertyName(JsonKeys.ModifiedBy)]
        public UserInfo ModifiedBy { get; init; } = default!;

        [JsonPropertyName(JsonKeys.CreatedTime)]
        public string CreatedTimeRaw { get; init; } = default!;

        [JsonIgnore]
        public DateTime CreatedTime =>
            ParseZohoDate(CreatedTimeRaw);

        [JsonPropertyName(JsonKeys.ModifiedTime)]
        public string ModifiedTimeRaw { get; init; } = default!;

        [JsonIgnore]
        public DateTime ModifiedTime =>
            ParseZohoDate(ModifiedTimeRaw);

        [JsonPropertyName(JsonKeys.BucketMeta)]
        public BucketMeta Meta { get; init; } = default!;

        private static DateTime ParseZohoDate(string raw) =>
            DateTime.ParseExact(
                raw,
                "MMM dd, yyyy hh:mm tt",
                CultureInfo.InvariantCulture);
    }
}
