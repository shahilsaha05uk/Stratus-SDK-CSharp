
namespace StratusSDK
{
    public sealed class DownloadOverridingQueryOptions
    {
        /// <summary>
        /// Refer to the https://www.iana.org/assignments/media-types/media-types.xhtml 
        /// for all the possible options. For example, "application/json" or "image/jpeg".
        /// </summary>
        public EContentType? ResponseContentType { get; set; }
        public string? ResponseContentLanguage { get; set; }
        public string? ResponseContentDisposition { get; set; }
        public string? ResponseCacheControl { get; set; }
    }
}
