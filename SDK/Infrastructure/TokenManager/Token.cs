namespace StratusSDK
{
    public sealed class Token(string accessToken, int expiresIn, string scope)
    {
        public string AccessToken { get; private set; } = accessToken;
        public int ExpiresIn { get; private set; } = expiresIn;
        public string Scope { get; private set; } = scope;
        public DateTime LastFetched { get; private set; } = DateTime.UtcNow;

        //public void Log()
        //{
        //    Console.WriteLine($"AccessToken: {AccessToken}");
        //    Console.WriteLine($"ExpiresIn: {ExpiresIn} seconds");
        //    Console.WriteLine($"Scope: {Scope}");
        //    Console.WriteLine($"LastFetched: {LastFetched:u}");
        //}
    }
}
