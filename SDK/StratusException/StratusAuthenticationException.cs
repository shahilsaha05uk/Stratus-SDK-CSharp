namespace StratusSDK
{
    /// <summary>
    /// Exception thrown when authentication with Zoho OAuth fails.
    /// </summary>
    /// <remarks>
    /// This exception is thrown when there are issues with the OAuth credentials
    /// such as invalid client ID, client secret, or refresh token.
    /// </remarks>
    /// <remarks>
    /// Initializes a new instance of the StratusAuthenticationException class.
    /// </remarks>
    /// <param name="message">The error message describing the authentication failure.</param>
    public sealed class StratusAuthenticationException(string message) : Exception(message)
    {
    }
}
