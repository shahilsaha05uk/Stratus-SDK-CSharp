namespace StratusSDK
{
    internal static class StratusRequestOptions
    {
        public static readonly HttpRequestOptionsKey<bool>
            RequireAuth = new("RequireAuth");
        public static readonly HttpRequestOptionsKey<bool>
            IncludeOrgId = new("IncludeOrg");
        public static readonly HttpRequestOptionsKey<bool>
            IncludeEnvironment = new("IncludeEnvironment");
    }
}
