

namespace StratusSDK
{
    public sealed class DownloadObjectQueryOptions : QueryProviderBase<DownloadObjectRequest>
    {
        /// <summary>
        /// Gets or initializes the specific version ID to download (optional).
        /// </summary>
        /// <value>The version ID or null for latest version.</value>
        public string? VersionId { get; init; } = default!;

        public override Dictionary<string, string?> ToQueries(DownloadObjectRequest data)
        {
            AddOptional(QueryKeys.VersionId, VersionId);
            if(data.OverridingQueryOptions is not null)
            {
                var query = data.OverridingQueryOptions;
                AddOptional(QueryKeys.ResponseContentType, query.ResponseContentType?.ToMimeString());
                AddOptional(QueryKeys.ResponseContentLanguage, query.ResponseContentLanguage);
                AddOptional(QueryKeys.ResponseContentDisposition, query.ResponseContentDisposition);
                AddOptional(QueryKeys.ResponseCacheControl, query.ResponseCacheControl);
            }
            return base.ToQueries(data);
        }
    }
}
