using System.Text.Json.Serialization;
using StratusSDK;
using StratusSDK.Core.Enums;

namespace StratusSDK.Api.GetStatusOfZipExtract.Models
{
    public sealed class GetStatusOfZipExtractData
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EZipExtractStatus Status { get; set; }
    }
}
