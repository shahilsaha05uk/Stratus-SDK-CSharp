using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Enums;

namespace StratusSDK.Api.Bucket.GetBuckets.Models
{
    public sealed class ProjectDetails
    {
        [JsonPropertyName("project_name")]
        public string Name { get; init; } = default!;

        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("project_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EProjectType Type { get; init; }
    }
}