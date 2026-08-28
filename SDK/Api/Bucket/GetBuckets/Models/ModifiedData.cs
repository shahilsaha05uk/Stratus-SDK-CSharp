using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Constants.Keys;
using StratusSDK.Core.Enums;

namespace StratusSDK.Api.Bucket.GetBuckets.Models
{
    public sealed class ModifiedData
    {
        [JsonPropertyName(JsonKeys.Zuid)]
        public long Zuid { get; init; }

        [JsonPropertyName(JsonKeys.IsConfirmed)]
        public bool IsConfirmed { get; init; }

        [JsonPropertyName(JsonKeys.EmailId)]
        public string EmailID { get; init; } = default!;

        [JsonPropertyName(JsonKeys.FirstName)]
        public string FirstName { get; init; } = default!;

        [JsonPropertyName(JsonKeys.LastName)]
        public string LastName { get; init; } = default!;

        [JsonPropertyName(JsonKeys.UserType)]
        public EUserType UserType { get; init; }

        [JsonPropertyName(JsonKeys.UserId)]
        public long UserID { get; init; }
    }
}