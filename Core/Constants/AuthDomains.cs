namespace StratusSDK.Core.Constants
{
    internal static class AuthDomains
    {
        static readonly Dictionary<ERegion, string> Domains = new()
        {
            { ERegion.US, "https://accounts.zoho.com/" },
            { ERegion.EU, "https://accounts.zoho.eu/" },
            { ERegion.AU, "https://accounts.zoho.au" },
            { ERegion.IN, "https://accounts.zoho.in/" },
            { ERegion.CA, "https://accounts.zohocloud.ca/" },
            { ERegion.JP, "https://accounts.zohocloud.jp/" },
            { ERegion.SA, "https://accounts.zohocloud.sa/" },
        };
        public static string GetDomain(ERegion region)
            => Domains.TryGetValue(region, out var domain)
            ? domain
            : throw new ArgumentException($"Unsupported region: {region}");
    }
}
