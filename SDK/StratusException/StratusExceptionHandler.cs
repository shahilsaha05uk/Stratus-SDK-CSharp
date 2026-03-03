using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StratusSDK
{
    public sealed class StratusExceptionHandler(
        ILogger<StratusExceptionHandler> logger)
        : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken ct)
        {
            if (exception is not StratusException se)
                return false;

            if (context.Response.HasStarted)
                return false;

            logger.LogError(
                se,
                "Stratus exception occurred. StatusCode={StatusCode}, ErrorCode={ErrorCode}",
                (int)se.StatusCode,
                se.ErrorCode);

            var problem = CreateProblemDetails(context, se);

            context.Response.StatusCode = (int)se.StatusCode;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(problem, ct);
            return true;
        }

        private static ProblemDetails CreateProblemDetails(
            HttpContext context,
            StratusException ex)
        {
            var problem = new ProblemDetails
            {
                Title = "Stratus API Error",
                Status = (int)ex.StatusCode,
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            AddIfNotNull(problem, "method", ex.Method);
            AddIfNotNull(problem, "url", ex.RequestUrl);
            AddIfNotNull(problem, "requestBody", ex.RequestBody);
            AddIfNotNull(problem, "responseBody", ex.ResponseBody);
            AddIfNotNull(problem, "errorCode", ex.ErrorCode);
            AddIfNotNull(problem, "queries", ex.QueryParams);
            return problem;
        }

        private static void AddIfNotNull(
            ProblemDetails problem,
            string key,
            object? value)
        {
            if (value is not null)
                problem.Extensions[key] = value;
        }
    }
}