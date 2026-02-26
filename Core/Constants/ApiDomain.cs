namespace StratusSDK
{
    internal static class ApiDomain
    {
        static readonly Dictionary<ERegion, string> Domains = new()
        {
            { ERegion.US, "https://api.catalyst.zoho.com"  },
            { ERegion.EU, "https://api.catalyst.zoho.eu" },
            { ERegion.IN, "https://api.catalyst.zoho.in" },
            { ERegion.JP, "https://api.catalyst.zoho.jp" },
            { ERegion.CA, "https://api.catalyst.zohocloud.ca" },
            { ERegion.SA, "https://api.catalyst.zoho.com.sa" },
            { ERegion.AU, "https://api.catalyst.zoho.com.au" },
        };

        public static string GetDomain(ERegion region)
            => Domains.TryGetValue(region, out var domain)
            ? domain
            : throw new ArgumentException($"Unsupported region: {region}");
    }

}
