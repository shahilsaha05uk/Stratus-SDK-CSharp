using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace StratusSDK
{
    /// <summary>
    /// This class will handle adding all the headers 
    /// to the request for authentication and 
    /// other necessary information like org id, environment etc.
    /// </summary>
    internal sealed class StratusDelegatingHandler(
        StratusOptions options,
        ITokenManager tokenManager) :
        DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken ct)
        {
            // Default behavior: Auth required
            var requireAuth = request.Options.TryGetValue(
                StratusRequestOptions.RequireAuth,
                out bool auth) ? auth : true;

            if (requireAuth)
            {
                var token = await tokenManager.GetToken(ct);
                request.Headers.Authorization =
                   new AuthenticationHeaderValue(
                       "Bearer",
                       token.AccessToken);
            }

            // Accept header always safe
            if (!request.Headers.Accept.Any())
            {
                request.Headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            // Org header toggle
            var includeOrgId = request.Options.TryGetValue(
                StratusRequestOptions.IncludeOrgId,
                out bool org) ? org : true;

            if (includeOrgId && !string.IsNullOrEmpty(options.OrgId))
            {
                request.Headers.Add(
                    "CATALYST-ORG",
                    options.OrgId);
            }

            // Environment header toggle
            var includeEnvironment = request.Options.TryGetValue(
                StratusRequestOptions.IncludeEnvironment,
                out bool env) ? env : false;

            if (includeEnvironment && options.Environment.HasValue)
            {
                request.Headers
                    .Add(
                    "Environment",
                    options.Environment.Value.ToString());
            }

            return await base.SendAsync(request, ct);
        }
    }
}