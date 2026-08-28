using System.Text.Json.Serialization;
using StratusSDK;

namespace StratusSDK.Core.Enums
{
    /// <summary>
    /// Specifies the type of a storage key in Stratus.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EStratusKeyType
    {
        /// <summary>
        /// Represents a file object.
        /// </summary>
        File,

        /// <summary>
        /// Represents a folder (directory) object.
        /// </summary>
        Folder
    }
}
