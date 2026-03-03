using System.Text.Json.Serialization;

namespace StratusSDK
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