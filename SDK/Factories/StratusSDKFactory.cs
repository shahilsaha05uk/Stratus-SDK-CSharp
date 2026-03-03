
namespace StratusSDK
{
    /// <summary>
    /// Factory class for creating instances of the Stratus SDK.
    /// </summary>
    /// <remarks>
    /// This factory provides a convenient way to instantiate the SDK with the required configuration.
    /// </remarks>
    public static class StratusSDKFactory
    {
        /// <summary>
        /// Creates a new instance of the Stratus SDK with the specified configuration.
        /// </summary>
        /// <param name="options">The configuration options for the SDK.</param>
        /// <returns>An IStratusSDK instance configured with the provided options.</returns>
        /// <example>
        /// <code>
        /// var options = new StratusOptions
        /// {
        ///     BucketName = "my-bucket",
        ///     ProjectID = "project-id",
        ///     Region = ERegion.US,
        ///     ClientID = "client-id",
        ///     ClientSecret = "client-secret",
        ///     RefreshToken = "refresh-token"
        /// };
        /// var sdk = StratusSDKFactory.Create(options);
        /// </code>
        /// </example>
        public static IStratusSDK Create(StratusOptions options)
            => new StratusSDK(new ManualResolver(options));
    }
}
