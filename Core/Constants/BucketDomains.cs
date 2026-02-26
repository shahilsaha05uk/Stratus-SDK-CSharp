namespace StratusSDK
{
    internal static class BucketDomains
    {
        static readonly Dictionary<ERegion, string> Domains = new()
        {
            { ERegion.US, "zohostratus.com" },
            { ERegion.EU, "zohostratus.eu" }
        };

        public static string GetDomain(ERegion region)
            => Domains.TryGetValue(region, out var domain)
            ? domain
            : throw new ArgumentException($"Unsupported region: {region}");
    }

}
